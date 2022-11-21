import { Button, Segment } from "semantic-ui-react";
import { useStore } from "../../stores/store";
import { displayOrNone } from "../stylesHelper";

export default function AddEntry() {
  const { stateEntryStore } = useStore();
  const { addMode, editMode, handleNewMode } = stateEntryStore;
  return (
    <Segment
      basic
      textAlign="center"
      style={{
        display: displayOrNone(!editMode && !addMode),
      }}
    >
      <Button circular color="green" onClick={handleNewMode}>
        Add new entry
      </Button>
    </Segment>
  );
}
