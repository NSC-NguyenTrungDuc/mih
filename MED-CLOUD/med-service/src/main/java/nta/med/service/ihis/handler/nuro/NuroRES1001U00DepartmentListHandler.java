package nta.med.service.ihis.handler.nuro;

import javax.annotation.Resource;

import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class NuroRES1001U00DepartmentListHandler extends ScreenHandler<NuroServiceProto.NuroRES1001U00DepartmentListRequest, NuroServiceProto.ComboListResponse>{
	private static final Log LOGGER = LogFactory.getLog(NuroRES1001U00DepartmentListHandler.class);
	@Resource
	private Adm3200Repository adm3200Repository;

//    @Override
//    public void handle(Message<byte[]> message) {
//        Rpc.RpcMessage rpcMessage;
//        try {
//        	LOGGER.info("[START] NuroRES1001U00DepartmentListHandler");
//            rpcMessage = Rpc.RpcMessage.parseFrom(message.body());
//            Rpc.RpcMessage.Builder rpcBuilder = RpcMessageBuilder.reply(rpcMessage);
//            NuroServiceProto.NuroRES1001U00DepartmentListRequest request = NuroServiceProto.NuroRES1001U00DepartmentListRequest.parseFrom(rpcMessage.getPayloadData());
//            LOGGER.info("REQUEST :" + request.toString());
////            List<String> listObject = adm3200Repository.getUserNameByUserId(getHospitalCode(), request.getUserId());
//
//            NuroServiceProto.ComboListResponse.Builder response = NuroServiceProto.ComboListResponse.newBuilder();
////            if (listObject != null && !listObject.isEmpty()) {
////                for (String obj : listObject) {
////                    response.setUserName(StringUtils.isEmpty(obj) ? "" : obj);
////                }
////            }
//            LOGGER.info("RESPONSE" + response.build().toString());
//            rpcBuilder.setPayloadClass(NuroServiceProto.ComboListResponse.class.getSimpleName());
//            rpcBuilder.setPayloadData(response.build().toByteString());
//            rpcBuilder.setResult(Rpc.RpcMessage.Result.SUCCESS);
//
//            message.reply(rpcBuilder.build().toByteArray());
//            LOGGER.info("[END] NuroRES1001U00DepartmentListHandler");
//        } catch (InvalidProtocolBufferException e) {
//        	LOGGER.error(e.getMessage(),e);
//        }
//    }

	@Override
	@Transactional
	public NuroServiceProto.ComboListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroRES1001U00DepartmentListRequest request) throws Exception {
		NuroServiceProto.ComboListResponse.Builder response = NuroServiceProto.ComboListResponse.newBuilder();
		return response.build();
	}
}
