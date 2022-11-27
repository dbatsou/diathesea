import { Dimmer, Loader } from "semantic-ui-react";

export default function LoadingComponent({
  inverted = true,
  content = "Loading...",
}) {
  return (
    <Dimmer active={true} inverted={inverted}>
      <Loader content={content} />
    </Dimmer>
  );
}
