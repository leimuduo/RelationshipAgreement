import { commonService } from "../common";
import { userEndpoint } from "./endpoints";

export const remove = (userId) => commonService.remove(
  `${userEndpoint}/${userId}`
)