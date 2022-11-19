import { Button, Segment } from "semantic-ui-react";
import { displayOrNone } from "../stylesHelper";

interface Props {
  handleNewMode: () => void;
  editMode: boolean;
  addMode: boolean;
}

const AddEntry = ({ handleNewMode, editMode, addMode }: Props) => (
  <Segment
    basic
    textAlign="center"
    style={{
      display: displayOrNone(!editMode && !addMode),
    }}
  >
    <Button circular color="green" onClick={() => handleNewMode()}>
      Add new entry
    </Button>
  </Segment>
);

export default AddEntry;
