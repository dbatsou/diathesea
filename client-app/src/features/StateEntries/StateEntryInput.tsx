import SemanticDatepicker from "react-semantic-ui-datepickers";
import { Button, Form, Segment, TextArea } from "semantic-ui-react";
import { StateFormFormatted } from "../../app/models/state";
import { StateEntry } from "../../app/models/stateEntry";

interface Props {
  states: StateFormFormatted[];
  selectedStateEntry: StateEntry | undefined;
  cancel: () => void;
}

const StateEntryInput = ({ states, selectedStateEntry, cancel }: Props) => (
  <Segment>
    <Form>
      <SemanticDatepicker
        format="dddd DD MMMM YYYY"
        id="datepicker"
        value={selectedStateEntry && new Date(selectedStateEntry?.CreatedAt)}
        placeholder="Date"
      />
      <Form.Select
        options={states}
        placeholder="State"
        value={
          selectedStateEntry
            ? states.find((x) => x.stateid === selectedStateEntry.StateId)
                ?.value
            : ""
        }
      />
      <TextArea
        placeholder="Tell us more"
        value={selectedStateEntry ? selectedStateEntry?.Note : ""}
      />
      <Button
        floated="right"
        content={selectedStateEntry ? "Update" : "Save"}
        color="green"
        style={{ marginTop: "2em" }}
      />
      <Button
        floated="right"
        onClick={() => cancel()}
        content="Cancel"
        style={{ marginTop: "2em" }}
      />
    </Form>
  </Segment>
);

export default StateEntryInput;
