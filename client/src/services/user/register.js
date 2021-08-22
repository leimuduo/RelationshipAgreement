import { commonService } from "../common";
import { userEndpoint } from "./endpoints";

export const register = (data) => commonService.post(
  `${userEndpoint}/register`,
  data
)