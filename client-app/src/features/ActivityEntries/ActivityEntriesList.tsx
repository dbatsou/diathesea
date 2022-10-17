import { Button, Item, Label, Segment } from "semantic-ui-react";
import { ActivityEntry } from "../../app/models/activityentry";

interface Props {
  activityentries: ActivityEntry[];
}

export default function ActivityEntriesList({ activityentries }: Props) {
  return (
    <Segment>
      <Item.Group divided>
        {activityentries.map((activityentry) => (
          <Item key={activityentry.ActivityEntryId}>
            <Item.Content>
              <Item.Header as="a">
                {activityentry.CreatedAt.toString()}
              </Item.Header>
              <Item.Meta>{activityentry.StateId?.toString()}</Item.Meta>
              <Item.Description>
                <div>{activityentry.Note}</div>
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
