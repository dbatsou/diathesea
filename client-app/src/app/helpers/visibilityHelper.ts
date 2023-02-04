export default class Utils {
  static isVisible(value: boolean) {
    if (value) return "inline";
    return "none";
  }
}
