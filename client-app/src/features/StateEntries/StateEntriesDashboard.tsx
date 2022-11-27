import { observer } from "mobx-react-lite";
import { Container } from "semantic-ui-react";
import AddEntry from "../../app/layout/minis/AddEntry";
import { useStore } from "../../app/stores/store";
import StateEntriesList from "./StateEntriesList";
import StateEntryInput from "./StateEntryInput";

export default observer(function StateEntriesDashboard() {
  const { stateEntryStore } = useStore();
  return (
    <Container>
      <AddEntry />
      <StateEntryInput />
      <StateEntriesList />
    </Container>
  );
});
