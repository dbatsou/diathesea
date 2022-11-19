import { ChangeEvent, SyntheticEvent, useRef, useState } from "react";
import SemanticDatepicker from "react-semantic-ui-datepickers";
import { Button, Form, Segment } from "semantic-ui-react";
import { displayOrNone } from "../../app/layout/stylesHelper";
import { StateFormFormatted } from "../../app/models/state";
import { StateEntry } from "../../app/models/stateEntry";

interface Props {
  states: StateFormFormatted[];
  selectedStateEntry: StateEntry;
  cancel: () => void;
  editMode: boolean;
  addMode: boolean;
  createOrEditStateEntry: (stateEntry: StateEntry) => void;
}

export default function StateEntryInput({
  selectedStateEntry,
  states,
  cancel,
  editMode,
  addMode,
  createOrEditStateEntry,
}: Props) {
  const [currentDate, setCurrentDate] = useState(new Date());
  let initialState = selectedStateEntry
    ? selectedStateEntry
    : ({ Date: currentDate.toISOString() } as StateEntry);

  const [stateEntry, setStateEntry] = useState(initialState);

  function handleSubmit() {
    console.log("from handleSubmit(): ", stateEntry);
    createOrEditStateEntry(stateEntry);
  }

  function handleInputChange(
    event: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>
  ) {
    const { name, value } = event.target;
    handleSetStateEntry(name, value);
  }

  function handleDatePickerInputChange(event: any, data: any) {
    const { name, value } = data;
    const d = value as Date;
    // console.log("%d-%d-%d", d.getFullYear(), d.getUTCMonth(), d.getUTCDay());
    // console.log(value?.toLocaleString());
    // console.log(d.toUTCString());
    if (d) {
      console.log(d.toISOString());

      handleSetStateEntry(name, value);
    }
  }

  function handleSetStateEntry(name: string, value: any) {
    setStateEntry({
      ...stateEntry,
      [name]: value,
    });
  }

  return (
    <Segment clearing style={{ display: displayOrNone(editMode || addMode) }}>
      <Form onSubmit={handleSubmit} autoComplete="off">
        <SemanticDatepicker
          format="dddd DD MMMM YYYY"
          id="datepicker"
          placeholder="Date"
          name="Date"
          onChange={handleDatePickerInputChange}
          // value={Date.parse(stateEntry.Date)}
          value={new Date(stateEntry.Date)}
        />

        {/* <Form.Input
          name="Date"
          value={stateEntry?.Date.toString()}
          onChange={handleInputChange}
        /> */}

        <Form.Select
          options={states}
          placeholder="State"
          name="StateId"
          value={states.find((x) => x.stateid === stateEntry?.StateId)?.value}
          onChange={(event, data) => {
            const { name, value } = data;
            const stateid = states.find(
              (state) => state.value === data.value
            )?.stateid;
            setStateEntry({
              ...stateEntry!,
              [name]: stateid ?? -1,
            });
          }}
        />
        <Form.TextArea
          name="Note"
          placeholder="Tell me more"
          value={stateEntry!.Note}
          onChange={handleInputChange}
        />
        <Button
          floated="right"
          color="green"
          content={editMode ? "Update" : "Save"}
          style={{ marginTop: "2em" }}
          type="submit"
        />
        <Button
          floated="right"
          onClick={() => cancel()}
          content="Cancel"
          style={{ marginTop: "2em" }}
          type="reset"
        />
      </Form>
    </Segment>
  );
}
