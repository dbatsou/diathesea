import { observer } from "mobx-react-lite";
import { useEffect } from "react";
import { Link } from "react-router-dom";
import { Button, Item, Segment } from "semantic-ui-react";
import { useStore } from "../../app/stores/store";

export default observer(function StateEntriesList() {
  const { stateEntryStore, stateStore } = useStore();

  useEffect(() => {
    stateEntryStore.loadStateEntries();
  }, [stateEntryStore, stateEntryStore.loadingInitial, stateStore]);

  return (
    <Segment
      style={{
        marginTop: "0em",
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
                as={Link}
                to={`/state/edit/${stateEntry.StateEntryId}`}
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
