package nta.med.service.ihis.handler.ocso;

//@Service
//@Scope("prototype")
//public class OCS0132CodeNameListHandler extends ScreenHandler implements Handler<Message<byte[]>> {
//	private static final Log LOGGER = LogFactory.getLog(OCS0132CodeNameListHandler.class);
//
//	@Resource
//	private Ocs0132Repository ocs0132Repository;
//	
//	@Override
//	public void handle(Message<byte[]> message) {
//		LOGGER.info("[START] OCS0132CodeNameListHandler ");
//		Rpc.RpcMessage rpcMessage;
//		try {
//			rpcMessage = Rpc.RpcMessage.parseFrom(message.body());
//			Rpc.RpcMessage.Builder rpcBuilder = RpcMessageBuilder.reply(rpcMessage);
//			OcsoServiceProto.OCS0132CodeNameListRequest request = OcsoServiceProto.OCS0132CodeNameListRequest.parseFrom(rpcMessage.getPayloadData());
//			LOGGER.info("REQUEST: " + request.toString());
//			
//			List<String> listObject = ocs0132Repository.getOCS0132CodeNameList(getLanguage(), request.getCodeType(), request.getCode());
//			OcsoServiceProto.OCS0132CodeNameListResponse.Builder response = OcsoServiceProto.OCS0132CodeNameListResponse.newBuilder();
//			if (listObject != null && !listObject.isEmpty()) {
//				for (String obj : listObject) {
//					response.addCodeName(obj);
//				}
//			}
//			rpcBuilder.setPayloadClass(OcsoServiceProto.OCS0132CodeNameListResponse.class.getSimpleName());
//			rpcBuilder.setPayloadData(response.build().toByteString());
//			LOGGER.info("RESPONSE: " + response.build().toString());
//			message.reply(rpcBuilder.build().toByteArray());
//			LOGGER.info("[END] OCS0132CodeNameListHandler ");
//		}catch (Exception e) {
//			LOGGER.error(e.getMessage(), e);
//			throw new RuntimeException(e.getMessage(), e);
//		}
//	}
//}
