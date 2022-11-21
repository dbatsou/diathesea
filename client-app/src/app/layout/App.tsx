import { useEffect } from "react";
import { Container } from "semantic-ui-react";
import NavBar from "./NavBar";
import StateEntriesDashboard from "../../features/StateEntries/StateEntriesDashboard";
import LoadingComponent from "./LoadingComponent";
import { observer } from "mobx-react-lite";
import { useStore } from "../stores/store";

function App() {
  const { stateEntryStore, stateStore } = useStore();

  useEffect(() => {
    stateStore.loadStates();
    stateEntryStore.loadStateEntries();
  }, [stateEntryStore, stateStore]);

  if (stateEntryStore.loadingInitial || stateStore.loadingInitial)
    return <LoadingComponent />;
  return (
    <>
      <NavBar />
      <Container style={{ marginTop: "4em" }}>
        <StateEntriesDashboard />
      </Container>
    </>
  );
}

export default observer(App);
