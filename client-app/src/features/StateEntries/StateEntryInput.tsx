import { observer } from "mobx-react-lite";
import { ChangeEvent, useEffect, useState } from "react";
import { Link, useNavigate, useParams } from "react-router-dom";
import SemanticDatepicker from "react-semantic-ui-datepickers";
import { Button, Form, Segment } from "semantic-ui-react";
import { StateEntry } from "../../app/models/stateEntry";
import { useStore } from "../../app/stores/store";

export default observer(function StateEntryInput() {
  const { stateEntryStore, stateStore } = useStore();
  const { createOrEditStateEntry, loadStateEntry } = stateEntryStore;
  const navigate = useNavigate();
  const [currentDate] = useState(new Date());
  const startState = {
    Date: currentDate.toISOString(),
  };
  const [stateEntry, setStateEntry] = useState<StateEntry>(startState);

  let { id } = useParams<{ id: string }>();

  useEffect(() => {
    try {
      if (id && parseInt(id)) {
        let entry = loadStateEntry(Number.parseInt(id!)).then((x) => {
          setStateEntry(x!);
        });
      } else {
        setStateEntry(startState);
      }
    } catch (error) {
      console.log(error);
    }
  }, [id, loadStateEntry]);

  function handleSubmit() {
    console.log("from handleSubmit(): ", stateEntry);
    createOrEditStateEntry(stateEntry);
    navigate("/history");
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
    if (d) {
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
    <Segment clearing>
      <Form onSubmit={handleSubmit} autoComplete="off">
        <SemanticDatepicker
          format="dddd DD MMMM YYYY"
          id="datepicker"
          placeholder="Date"
          name="Date"
          onChange={handleDatePickerInputChange}
          value={new Date(stateEntry.Date)}
        />

        <Form.Select
          options={stateStore.states}
          placeholder="State"
          name="StateId"
          value={
            stateStore.states.find(
              (x) => x.stateid > 0 && x.stateid === stateEntry?.StateId
            )?.text || ""
          }
          onChange={(event, data) => {
            const { name } = data;
            const stateid = stateStore.states.find(
              (state) => state.value === data.value
            )?.stateid;
            setStateEntry({
              ...stateEntry!,
              [name]: stateid ?? "",
            });
          }}
        />
        <Form.TextArea
          name="Note"
          placeholder="Tell me more"
          value={(stateEntry && stateEntry!.Note) || ""}
          onChange={handleInputChange}
        />
        <Button
          floated="right"
          color="green"
          content={id ? "Update" : "Save"}
          style={{ marginTop: "2em" }}
          type="submit"
        />
        <Button
          floated="right"
          as={Link}
          to="/history"
          content="Cancel"
          style={{ marginTop: "2em" }}
          type="reset"
        />
      </Form>
    </Segment>
  );
});
