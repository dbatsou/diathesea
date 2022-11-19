import { useEffect, useState } from "react";
import { Container } from "semantic-ui-react";
import NavBar from "./NavBar";
import agent from "../api/agent";
import { StateFormFormatted } from "../models/state";
import { StateEntry } from "../models/stateEntry";
import StateEntriesDashboard from "../../features/StateEntries/StateEntriesDashboard";
import LoadingComponent from "./LoadingComponent";

function App() {
  const [stateEntries, setStateEntries] = useState<StateEntry[]>([]);
  const [states, setStates] = useState<StateFormFormatted[]>([]);
  const [isLoading, setLoading] = useState(true);
  const [isSubmitting, setSubmitting] = useState(false);
  const [editMode, setEditMode] = useState(false);
  const [addMode, setAddMode] = useState(false);

  const [selectedStateEntry, setSelectedStateEntry] = useState<
    StateEntry | undefined
  >(undefined);

  function handleSelectStateEntry(stateEntryId: number) {
    setSelectedStateEntry(
      stateEntries.find((x) => x.StateEntryId === stateEntryId)
    );
  }

  function handleFormOpen(id?: number) {
    id ? handleSelectStateEntry(id) : handleCancelSelectStateEntry();
    setEditMode(true);
  }

  function handleFormClose() {
    setEditMode(false);
  }

  function handleCancelSelectStateEntry() {
    setSelectedStateEntry(undefined);
    setEditMode(false);
    setAddMode(false);
  }

  function handleNewMode() {
    setAddMode(true);
  }

  function handleDeleteStateEntry(id: number) {
    setLoading(true);

    agent.StateEntries.delete(id).then();
    {
      var filteredStateEntries = stateEntries.filter(
        (x) => x.StateEntryId !== id
      );
      setStateEntries(filteredStateEntries);
      setLoading(false);
    }
  }

  function createOrEditStateEntry(stateEntry: StateEntry) {
    console.log("from createOrEditStateEntry(): ", stateEntry);

    if (stateEntry.StateEntryId) {
      console.log("edit");

      agent.StateEntries.update(stateEntry)
        .then((response) => {
          if (response.status === 200) fetchStateEntries();
        })
        .catch((error) => {
          console.log(error);
        });
    } else {
      console.log("create");
      agent.StateEntries.create(stateEntry)
        .then((response) => {
          if (response.status === 201) fetchStateEntries();
        })
        .catch((error) => {
          console.log(error);
        });
    }
    setEditMode(false);
    setAddMode(false);
  }

  function fetchStateEntries() {
    agent.StateEntries.list().then((response) => {
      setStateEntries(response);
    });
  }
  useEffect(() => {
    agent.States.list().then((response) => {
      //the following is performed because the semantic ui dropdown component needs the array in the format below key / text / value
      const statesFormatted: StateFormFormatted[] = [];
      response.forEach((value) => {
        statesFormatted.push({
          key: value.StateId,
          text: value.StateName,
          value: value.StateName,
          stateid: value.StateId, //not sure why the key prop always comes w/ 0 and the stateid with the right value TODO check
        });
        setStates(statesFormatted);
        setLoading(false);
      });
    });

    fetchStateEntries();
  }, []);

  if (isLoading) return <LoadingComponent />;
  return (
    <>
      <NavBar />
      <Container style={{ marginTop: "4em" }}>
        <StateEntriesDashboard
          states={states}
          stateEntries={stateEntries}
          selectStateEntry={handleSelectStateEntry}
          selectedStateEntry={selectedStateEntry}
          cancelStateEntry={handleCancelSelectStateEntry}
          deleteStateEntry={handleDeleteStateEntry}
          editMode={editMode}
          addMode={addMode}
          handleNewMode={handleNewMode}
          createOrEditStateEntry={createOrEditStateEntry}
          openForm={handleFormOpen}
          closeForm={handleFormClose}
        />
      </Container>
    </>
  );
}

export default App;
