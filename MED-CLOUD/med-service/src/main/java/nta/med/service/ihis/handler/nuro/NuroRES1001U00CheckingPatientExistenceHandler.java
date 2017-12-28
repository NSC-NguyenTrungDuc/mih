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
public class NuroRES1001U00CheckingPatientExistenceHandler extends ScreenHandler<NuroServiceProto.NuroRES1001U00CheckingPatientExistenceRequest, NuroServiceProto.NuroRES1001U00CheckingPatientExistenceResponse> {
	private static final Log LOGGER = LogFactory.getLog(NuroRES1001U00CheckingPatientExistenceHandler.class);
	@Resource
	private Adm3200Repository adm3200Repository;

//    @Override
//    public void handle(Message<byte[]> message) {
//        Rpc.RpcMessage rpcMessage;
//        try {
//        	LOGGER.info("[START] NuroRES1001U00CheckingPatientExistenceHandler");
//            rpcMessage = Rpc.RpcMessage.parseFrom(message.body());
//            Rpc.RpcMessage.Builder rpcBuilder = RpcMessageBuilder.reply(rpcMessage);
//            NuroServiceProto.NuroRES1001U00CheckingPatientExistenceRequest request = NuroServiceProto.NuroRES1001U00CheckingPatientExistenceRequest.parseFrom(rpcMessage.getPayloadData());
//            LOGGER.info("REQUEST :" + request.toString());
////            List<String> listObject = adm3200Repository.getUserNameByUserId(getHospitalCode(), request.getUserId());
//
//            NuroServiceProto.NuroRES1001U00CheckingPatientExistenceResponse.Builder response = NuroServiceProto.NuroRES1001U00CheckingPatientExistenceResponse.newBuilder();
////            if (listObject != null && !listObject.isEmpty()) {
////                for (String obj : listObject) {
////                    response.setUserName(StringUtils.isEmpty(obj) ? "" : obj);
////                }
////            }
//            LOGGER.info("RESPONSE" + response.build().toString());
//            rpcBuilder.setPayloadClass(NuroServiceProto.NuroRES1001U00CheckingPatientExistenceResponse.class.getSimpleName());
//            rpcBuilder.setPayloadData(response.build().toByteString());
//            rpcBuilder.setResult(Rpc.RpcMessage.Result.SUCCESS);
//
//            message.reply(rpcBuilder.build().toByteArray());
//            LOGGER.info("[END] NuroRES1001U00CheckingPatientExistenceHandler");
//        } catch (InvalidProtocolBufferException e) {
//        	LOGGER.error(e.getMessage(),e);
//        }
//    }

	@Override
	@Transactional
	public NuroServiceProto.NuroRES1001U00CheckingPatientExistenceResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroRES1001U00CheckingPatientExistenceRequest request) throws Exception {
		NuroServiceProto.NuroRES1001U00CheckingPatientExistenceResponse.Builder response = NuroServiceProto.NuroRES1001U00CheckingPatientExistenceResponse.newBuilder();
		return response.build();
	}
}
