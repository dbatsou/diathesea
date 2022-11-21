import { observer } from "mobx-react-lite";
import { Button, Item, Segment } from "semantic-ui-react";
import { displayOrNone } from "../../app/layout/stylesHelper";
import { useStore } from "../../app/stores/store";

export default observer(function StateEntriesList() {
  const { stateEntryStore, stateStore } = useStore();
  const { addMode, editMode } = stateEntryStore;

  return (
    <Segment
      style={{
        marginTop: "0em",
        display: displayOrNone(
          stateEntryStore.stateEntries.length > 0 && !editMode && !addMode
        ),
      }}
    >
      {/* <Divider /> */}
      <Item.Group divided>
        {stateEntryStore.stateEntries.map((stateEntry, index) => (
          <Item key={index}>
            <Item.Content>
              <Item.Header as="a">
                {new Date(stateEntry.Date).toLocaleString().split(",")[0]}
                {/*just display the date for now, time later stage */}
              </Item.Header>
              <Item.Meta>
                {
                  stateStore.states.find(
                    (x) => x.stateid === stateEntry.StateId
                  )?.value
                }
              </Item.Meta>
              <Item.Description>
                <div>{stateEntry.Note}</div>
              </Item.Description>
              <Button
                onClick={() =>
                  stateEntryStore.handleDeleteStateEntry(
                    stateEntry.StateEntryId!
                  )
                }
                floated="right"
                content="Delete"
                color="red"
              />
              <Button
                onClick={() =>
                  stateEntryStore.handleFormOpen(stateEntry.StateEntryId!)
                }
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
});
