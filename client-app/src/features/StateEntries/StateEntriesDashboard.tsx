import { Button, Container } from "semantic-ui-react";
import AddEntry from "../../app/layout/minis/AddEntry";
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
  addMode: boolean;
  handleNewMode: () => void;
  createOrEditStateEntry: (stateEntry: StateEntry) => void;
  deleteStateEntry: (id: number) => void;
  closeForm: () => void;
  openForm: (id: number) => void;
}

export default function StateEntriesDashboard({
  states,
  stateEntries,
  selectedStateEntry,
  deleteStateEntry,
  selectStateEntry,
  cancelStateEntry,
  handleNewMode,
  editMode,
  addMode,
  openForm,
  createOrEditStateEntry,
}: Props) {
  return (
    <Container>
      <AddEntry
        handleNewMode={handleNewMode}
        editMode={editMode}
        addMode={addMode}
      />
      {(selectedStateEntry || addMode) && (
        <StateEntryInput
          states={states}
          selectedStateEntry={selectedStateEntry!}
          cancel={cancelStateEntry}
          editMode={editMode}
          addMode={addMode}
          createOrEditStateEntry={createOrEditStateEntry}
        />
      )}
      <StateEntriesList
        stateEntries={stateEntries}
        openForm={openForm}
        deleteStateEntry={deleteStateEntry}
        editMode={editMode}
        addMode={addMode}
        states={states}
      />
    </Container>
  );
}
