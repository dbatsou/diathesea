import { Button, Divider, Item, Label, Segment } from "semantic-ui-react";
import { StateEntry } from "../../app/models/stateEntry";

interface Props {
  stateEntries: StateEntry[];
  selectStateEntry: (id: number) => void;
  deleteStateEntry: (id: number) => void;
}

export default function StateEntriesList({
  stateEntries,
  selectStateEntry,
  deleteStateEntry,
}: Props) {
  return (
    <Segment>
      {/* <Divider /> */}
      <Item.Group divided>
        {stateEntries.map((stateEntry) => (
          <Item key={stateEntry.StateEntryId}>
            <Item.Content>
              <Item.Header as="a">
                {stateEntry.CreatedAt.toString()}
              </Item.Header>
              <Item.Meta>{stateEntry.StateId?.toString()}</Item.Meta>
              <Item.Description>
                <div>{stateEntry.Note}</div>
              </Item.Description>
              <Button
                onClick={() => deleteStateEntry(stateEntry.StateEntryId)}
                floated="right"
                content="Delete"
                color="red"
              />
              <Button
                onClick={() => selectStateEntry(stateEntry.StateEntryId)}
                floated="right"
                content="Edit"
                color="blue"
              />
            </Item.Content>
          </Item>
        ))}
      </Item.Group>
    </Segment>
  );
}
