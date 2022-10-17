import { Button, Item, Label, Segment } from "semantic-ui-react";
import { StateEntry } from "../../app/models/stateEntry";

interface Props {
  stateEntries: StateEntry[];
}

export default function StateEntriesList({ stateEntries }: Props) {
  return (
    <Segment>
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
              <Item.Extra>
                <Button
                  //onClick={() => deleteActivity(activityentry.id)}
                  floated="right"
                  content="Delete"
                  color="red"
                />
                {/* <Label basic content={activityentry.category} />  */}
              </Item.Extra>
            </Item.Content>
          </Item>
        ))}
      </Item.Group>
    </Segment>
  );
}
