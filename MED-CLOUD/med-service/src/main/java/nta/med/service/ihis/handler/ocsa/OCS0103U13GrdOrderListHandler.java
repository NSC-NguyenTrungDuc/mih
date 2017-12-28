package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.model.ihis.ocsa.OCS0103U13GrdOrderListInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U13GrdOrderListRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U13GrdOrderListResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0103U13GrdOrderListHandler 
	extends ScreenHandler<OcsaServiceProto.OCS0103U13GrdOrderListRequest, OcsaServiceProto.OCS0103U13GrdOrderListResponse> {                             
	private static final Log LOGGER = LogFactory.getLog(OCS0103U13GrdOrderListHandler.class);                                        
	@Resource                                                                                                       
	private Ocs1003Repository ocs1003Repository;                                                                    
	                                                                                                                
	@Override                 
	@Transactional(readOnly = true)
	public OCS0103U13GrdOrderListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0103U13GrdOrderListRequest request) throws Exception {                                                                   
  	   	OcsaServiceProto.OCS0103U13GrdOrderListResponse.Builder response = OcsaServiceProto.OCS0103U13GrdOrderListResponse.newBuilder();                      
		List<OCS0103U13GrdOrderListInfo> listGrdOrder=ocs1003Repository.getOCS0103U13GrdOrderListInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId),
				request.getOrderMode(),request.getMemb(),request.getYaksokCode(),request.getInputTab(),CommonUtils.parseDouble(request.getFkInOutKey()),"OCS0103U13GrdOrderListRequest");
		if(!CollectionUtils.isEmpty(listGrdOrder)){
			for(OCS0103U13GrdOrderListInfo item : listGrdOrder){
				OcsaModelProto.OCS0103U13GrdOrderListInfo.Builder info=OcsaModelProto.OCS0103U13GrdOrderListInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				if (item.getPkOrdKey() !=null) {
					info.setPkOrdKey(String.format("%.0f",item.getPkOrdKey()));
				}
				if(item.getSuryang() !=null){
					info.setSuryang(String.format("%.0f",item.getSuryang()));
				}
				if(item.getNalsu() !=null){
					info.setNalsu(String.format("%.0f",item.getNalsu()));
				}
				if(item.getDv() !=null){
					info.setDv(String.format("%.0f",item.getDv()));
				}
				if(item.getDv1() !=null){
					info.setDv1(String.format("%.0f",item.getDv1()));
				}
				if(item.getDv2() !=null){
					info.setDv2(String.format("%.0f",item.getDv2()));
				}
				if(item.getDv3() !=null){
					info.setDv3(String.format("%.0f",item.getDv3()));
				}
				if(item.getDv4() !=null){
					info.setDv4(String.format("%.0f",item.getDv4()));
				}
				if(item.getGroupSer() !=null){
					info.setGroupSer(String.format("%.0f",item.getGroupSer()));
				}
				if(item.getSeq() !=null){
					info.setSeq(String.format("%.0f",item.getSeq()));
				}
				response.addGrdOrderListItem(info);
			}
		}
		return response.build();
	}

}