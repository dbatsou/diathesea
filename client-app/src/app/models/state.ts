export interface State {
  StateId: number;
  Order: number;
  StateName: string;
  ParentStateID: number;
}

//this is only temporariliy used till i migrate to formik
export interface StateFormFormatted {
  key: number;
  value: string;
  text: string;
  stateid: number;
}
