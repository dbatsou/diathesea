import { Dimmer, Loader } from "semantic-ui-react";
import { TypePredicateKind } from "typescript";

interface Props {
  inverted?: boolean;
  content?: string;
}

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
