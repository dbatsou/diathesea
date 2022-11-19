import { Button, Divider, Item, Label, Segment } from "semantic-ui-react";
import { displayOrNone } from "../../app/layout/stylesHelper";
import { StateFormFormatted } from "../../app/models/state";
import { StateEntry } from "../../app/models/stateEntry";

interface Props {
  stateEntries: StateEntry[];
  openForm: (id: number) => void;
  deleteStateEntry: (id: number) => void;
  editMode: boolean;
  addMode: boolean;
  states: StateFormFormatted[];
}

export default function StateEntriesList({
  stateEntries,
  openForm,
  deleteStateEntry,
  editMode,
  addMode,
  states,
}: Props) {
  return (
    <Segment
      style={{
        marginTop: "0em",
        display: displayOrNone(
          stateEntries.length > 0 && !editMode && !addMode
        ),
      }}
    >
      {/* <Divider /> */}
      <Item.Group divided>
        {stateEntries.map((stateEntry, index) => (
          <Item key={index}>
            <Item.Content>
              <Item.Header as="a">
                {new Date(stateEntry.Date).toLocaleString()}
              </Item.Header>
              <Item.Meta>
                {states.find((x) => x.stateid === stateEntry.StateId)?.value}
              </Item.Meta>
              <Item.Description>
                <div>{stateEntry.Note}</div>
              </Item.Description>
              <Button
                onClick={() => deleteStateEntry(stateEntry.StateEntryId!)}
                floated="right"
                content="Delete"
                color="red"
              />
              <Button
                onClick={() => openForm(stateEntry.StateEntryId!)}
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
