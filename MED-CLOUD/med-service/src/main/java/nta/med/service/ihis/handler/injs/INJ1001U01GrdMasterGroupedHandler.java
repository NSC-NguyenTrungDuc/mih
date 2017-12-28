//package nta.med.service.ihis.handler.injs;
//
//import java.util.List;
//
//import javax.annotation.Resource;
//
//import nta.med.common.remoting.rpc.protobuf.Rpc;
//import nta.med.core.proto.util.RpcMessageBuilder;
//import nta.med.core.utils.DateUtil;
//import nta.med.data.dao.medi.inj.Inj1001Repository;
//import nta.med.data.dao.medi.inv.Inv0110Repository;
//import nta.med.data.model.ihis.injs.InjsINJ1001U01MasterListItemInfo;
//import nta.med.service.ScreenHandler;
//import nta.med.service.ihis.proto.InjsModelProto;
//import nta.med.service.ihis.proto.InjsServiceProto;
//
//import org.apache.commons.collections.CollectionUtils;
//import org.apache.commons.logging.Log;
//import org.apache.commons.logging.LogFactory;
//import org.springframework.context.annotation.Scope;
//import org.springframework.stereotype.Service;
//import org.springframework.util.StringUtils;
//import org.vertx.java.core.Handler;
//import org.vertx.java.core.eventbus.Message;
//
//@Service
//@Scope("prototype")
//public class INJ1001U01GrdMasterGroupedHandler extends ScreenHandler implements Handler<Message<byte[]>> {
//	private static final Log LOG = LogFactory.getLog(INJ1001U01GrdMasterGroupedHandler.class);
//	@Resource
//	private Inj1001Repository inj1001Repository;
//	
//	@Resource
//	private Inv0110Repository inv0110Repository;
//	
//	@Override
//	public void handle(Message<byte[]> message) {
//		LOG.info("[START] INJ1001U01GrdMasterGroupedHandler");
//		Rpc.RpcMessage rpcMessage;
//        try {
//            rpcMessage = Rpc.RpcMessage.parseFrom(message.body());
//            InjsServiceProto.INJ1001U01GrdMasterGroupedRequest request = InjsServiceProto.INJ1001U01GrdMasterGroupedRequest.parseFrom(rpcMessage.getPayloadData());
//            LOG.info("REQUEST: " + request.toString());
//            Rpc.RpcMessage.Builder rpcBuilder = RpcMessageBuilder.reply(rpcMessage);
//            InjsServiceProto.INJ1001U01GrdMasterGroupedResponse.Builder response = InjsServiceProto.INJ1001U01GrdMasterGroupedResponse.newBuilder();
//            if (!StringUtils.isEmpty(request.getReserDate()) && DateUtil.toDate(request.getReserDate(), DateUtil.PATTERN_YYMMDD) == null) {
//            	rpcBuilder.setResult(Rpc.RpcMessage.Result.SERVICE_REJECTED);
//            } else {
//            	List<InjsINJ1001U01MasterListItemInfo> listObject = inj1001Repository.getInjsINJ1001U01MasterListItemInfo(getHospitalCode(), request.getGwa(), request.getReserDate(), request.getActingFlag());
//            	if (!CollectionUtils.isEmpty(listObject)) {
//	            	for (InjsINJ1001U01MasterListItemInfo item : listObject) {
//	            		InjsModelProto.InjsINJ1001U01MasterListItemInfo.Builder info = InjsModelProto.InjsINJ1001U01MasterListItemInfo.newBuilder();
//	            		if (!StringUtils.isEmpty(item.getReserGubun())) {
//	            			info.setReserGubun(item.getReserGubun());
//	            		}
//	            		if (!StringUtils.isEmpty(item.getBunho())) {
//	            			info.setBunho(item.getBunho());
//	            		}
//	            		if (!StringUtils.isEmpty(item.getSuname())) {
//	            			info.setSuname(item.getSuname());
//	            		}
//	            		if (!StringUtils.isEmpty(item.getOrderDate())) {
//	            			info.setOrderDate(item.getOrderDate());
//	            		}
//	            		if (!StringUtils.isEmpty(item.getReserDate())) {
//	            			info.setReserDate(item.getReserDate());
//	            		}
//
//	            		response.addMasterListItem(info);
//	            		
//	            		String result = inv0110Repository.getInjsINJ1001U01ChkbState(getHospitalCode(), 
//	    	            		DateUtil.toDate(request.getReserDate(),DateUtil.PATTERN_YYMMDD), request.getActingFlag(), item.getBunho(), request.getDoctor());
//	            	}
//	            }
//	            LOG.info("RESPONSE: " + response.build().toString());
//	            
//	            rpcBuilder.setPayloadClass(InjsServiceProto.INJ1001U01GrdMasterGroupedResponse.class.getSimpleName());
//	            rpcBuilder.setPayloadData(response.build().toByteString());
//            }
//            message.reply(rpcBuilder.build().toByteArray());
//        } catch (Exception e) {
//        	LOG.error(e.getMessage(),e);
//        }
//        LOG.info("[END] INJ1001U01GrdMasterGroupedHandler");
//	}
//
//}
