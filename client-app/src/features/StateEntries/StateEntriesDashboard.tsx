import { Button, Container } from "semantic-ui-react";
import { StateFormFormatted } from "../../app/models/state";
import { StateEntry } from "../../app/models/stateEntry";
import StateEntriesList from "./StateEntriesList";
import StateEntryInput from "./StateEntryInput";

interface Props {
  states: StateFormFormatted[];
  stateEntries: StateEntry[];
  selectedStateEntry: StateEntry | undefined;
  selectStateEntry: (id: number) => void;
  cancelStateEntry: () => void;
  editMode: boolean;
  openForm: (id: number) => void;
  deleteStateEntry: (id: number) => void;
  closeForm: () => void;
}

export default function StateEntriesDashboard({
  states,
  stateEntries,
  selectedStateEntry,
  deleteStateEntry,
  selectStateEntry,
  cancelStateEntry,
  editMode,
  openForm,
  closeForm,
}: Props) {
  return (
    <Container>
      <StateEntriesList
        stateEntries={stateEntries}
        selectStateEntry={selectStateEntry}
        deleteStateEntry={deleteStateEntry}
      />
      <StateEntryInput
        states={states}
        selectedStateEntry={selectedStateEntry}
        cancel={cancelStateEntry}
      />
    </Container>
  );
}
