import { useEffect } from "react";
import { Container } from "semantic-ui-react";
import NavBar from "./NavBar";
import LoadingComponent from "./LoadingComponent";
import { observer } from "mobx-react-lite";
import { useStore } from "../stores/store";
import { Route, Routes, useLocation } from "react-router-dom";
import StateEntryInput from "../../features/StateEntries/StateEntryInput";
import StateEntriesList from "../../features/StateEntries/StateEntriesList";
import HomePage from "../../features/Homepage/HomePage";

function App() {
  const { stateEntryStore, stateStore } = useStore();
  const location = useLocation();
  useEffect(() => {
    stateStore.loadStates();
  }, [stateStore]);

  if (stateEntryStore.loadingInitial || stateStore.loadingInitial)
    return <LoadingComponent />;
  return (
    <>
      <NavBar />
      <Container style={{ marginTop: "4em" }}>
        <Routes>
          <Route path="/" element={<HomePage />} />
          <Route
            key={location.key}
            path="/state/new"
            element={<StateEntryInput />}
          />
          <Route
            key={location.key}
            path="/state/edit/:id"
            element={<StateEntryInput />}
          />
          <Route path="/history" element={<StateEntriesList />} />
        </Routes>
        {/* <StateEntriesDashboard /> */}
      </Container>
    </>
  );
}

export default observer(App);
