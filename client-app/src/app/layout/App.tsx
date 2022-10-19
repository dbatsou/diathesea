import { useEffect, useState } from "react";
import { Container } from "semantic-ui-react";
import NavBar from "./NavBar";
import agent from "../api/agent";
import { StateFormFormatted } from "../models/state";
import { StateEntry } from "../models/stateEntry";
import StateEntriesDashboard from "../../features/StateEntries/StateEntriesDashboard";
import LoadingComponent from "./LoadingComponent";

function App() {
  // const [states, SetStates] = useState<State[]>([]);
  const [stateEntries, SetStateEntries] = useState<StateEntry[]>([]);
  const [states, SetStates] = useState<StateFormFormatted[]>([]);
  const [isLoading, setLoading] = useState(true);
  const [isSubmitting, setSubmitting] = useState(false);
  const [editMode, setEditMode] = useState(false);
  const [selectedStateEntry, setSelectedStateEntry] = useState<
    StateEntry | undefined
  >(undefined);

  function handleSelectStateEntry(id: number) {
    var entry = stateEntries.find((x) => x.StateEntryId === id);
    setSelectedStateEntry(entry);
    setEditMode(true);
    console.log("set to " + id);
    console.log(entry);
  }

  function handleCancelSelectStateEntry() {
    setSelectedStateEntry(undefined);
    setEditMode(false);
    console.log("cancel", selectedStateEntry);
  }

  function handleFormOpen(id?: number) {
    id ? handleSelectStateEntry(id) : handleCancelSelectStateEntry();
    setEditMode(true);
  }

  function handleFormClose() {
    setEditMode(false);
  }

  function handleDeleteStateEntry(id: number) {
    setLoading(true);

    agent.StateEntries.delete(id).then();
    {
      var filteredStateEntries = stateEntries.filter(
        (x) => x.StateEntryId !== id
      );
      var removed = stateEntries.find((x) => x.StateEntryId === id);
      SetStateEntries(filteredStateEntries);
      console.log("removed: ", removed);
      setLoading(false);
    }
  }

  useEffect(() => {
    agent.States.list().then((response) => {
      const statesFormatted: StateFormFormatted[] = [];
      response.forEach((value) => {
        statesFormatted.push({
          key: value.StateId,
          text: value.StateName,
          value: value.StateName,
          stateid: value.StateId,
        });
        SetStates(statesFormatted);
        setLoading(false);
      });
    });

    agent.StateEntries.list().then((response) => {
      SetStateEntries(response);
    });
  }, []);

  if (isLoading) return <LoadingComponent />;
  return (
    <>
      <NavBar />
      <Container style={{ marginTop: "4em" }}>
        <StateEntriesDashboard
          stateEntries={stateEntries}
          states={states}
          openForm={handleFormOpen}
          closeForm={handleFormClose}
          selectStateEntry={handleSelectStateEntry}
          editMode={editMode}
          selectedStateEntry={selectedStateEntry}
          cancelStateEntry={handleCancelSelectStateEntry}
          deleteStateEntry={handleDeleteStateEntry}
        />
      </Container>
    </>
  );
}

export default App;
