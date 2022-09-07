import { useEffect, useState } from "react";
import axios from "axios";
import { Header, List } from "semantic-ui-react";

function App() {
  const [states, SetStates] = useState([]);

  useEffect(() => {
    axios.get("http://localhost:5000/api/state").then((response) => {
      console.log(response);
      SetStates(response.data);
    });
  }, []);

  return (
    <div className="">
      <Header as="h2" content="diathesea" />
      <List>
        {states.map((state: any) => (
          <List.Item key={state.StateId}>{state.StateName} </List.Item>
        ))}
      </List>
    </div>
  );
}

export default App;
