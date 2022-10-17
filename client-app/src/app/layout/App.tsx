import { useEffect, useState } from "react";
import { Container } from "semantic-ui-react";
import NavBar from "./NavBar";
import agent from "../api/agent";
import { State, StateFormFormatted } from "../models/state";
import { StateEntry } from "../models/stateEntry";
import StateEntriesDashboard from "../../features/StateEntries/StateEntriesDashboard";

function App() {
  // const [states, SetStates] = useState<State[]>([]);
  const [stateEntries, SetStateEntries] = useState<StateEntry[]>([]);
  const [states, SetStates] = useState<StateFormFormatted[]>([]);

  useEffect(() => {
    agent.States.list().then((response) => {
      const statesFormatted: StateFormFormatted[] = [];
      response.forEach((value) => {
        statesFormatted.push({
          key: value.StateId,
          text: value.StateName,
          value: value.StateName,
        });
      });
      console.log(statesFormatted);
      SetStates(statesFormatted);
    });

    agent.StateEntries.list().then((response) => {
      SetStateEntries(response);
    });
  }, []);

  return (
    <>
      <NavBar />
      <Container style={{ marginTop: "4em" }}>
        <StateEntriesDashboard stateEntries={stateEntries} states={states} />
      </Container>
    </>
  );
}

export default App;
