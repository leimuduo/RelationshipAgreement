import { commonService } from "../common";
import { userEndpoint } from "./endpoints";

export const get = (userId) => commonService.get(
  `${userEndpoint}/${userId}`
)