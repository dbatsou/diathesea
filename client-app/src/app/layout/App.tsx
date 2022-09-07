import { useEffect, useState } from "react";
import axios from "axios";
import { Header, List } from "semantic-ui-react";
import { State } from "../models/state";

function App() {
  const [states, SetStates] = useState<State[]>([]);

  useEffect(() => {
    axios.get<State[]>("http://localhost:5000/api/state").then((response) => {
      console.log(response);
      SetStates(response.data);
    });
  }, []);

  return (
    <div className="">
      <Header as="h2" content="diathesea" />
      <List>
        {states.map((state) => (
          <List.Item key={state.StateId}>{state.StateName} </List.Item>
        ))}
      </List>
    </div>
  );
}

export default App;
