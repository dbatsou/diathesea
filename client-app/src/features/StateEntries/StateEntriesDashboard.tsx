import { Container } from "semantic-ui-react";
import { StateFormFormatted } from "../../app/models/state";
import { StateEntry } from "../../app/models/stateEntry";
import StateEntriesList from "./StateEntriesList";
import StateEntryInput from "./StateEntryInput";

interface Props {
  states: StateFormFormatted[];
  stateEntries: StateEntry[];
}

export default function StateEntriesDashboard({ states, stateEntries }: Props) {
  return (
    <Container>
      <StateEntriesList stateEntries={stateEntries} />
      <StateEntryInput states={states} />
    </Container>
  );
}
