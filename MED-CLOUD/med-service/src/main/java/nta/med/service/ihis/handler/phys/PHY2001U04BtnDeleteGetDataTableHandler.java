package nta.med.service.ihis.handler.phys;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.model.ihis.phys.PHY2001U04BtnDeleteGetDataTableInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.PhysModelProto;
import nta.med.service.ihis.proto.PhysServiceProto;
import nta.med.service.ihis.proto.PhysServiceProto.PHY2001U04BtnDeleteGetDataTableRequest;
import nta.med.service.ihis.proto.PhysServiceProto.PHY2001U04BtnDeleteGetDataTableResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class PHY2001U04BtnDeleteGetDataTableHandler
	extends ScreenHandler<PhysServiceProto.PHY2001U04BtnDeleteGetDataTableRequest, PhysServiceProto.PHY2001U04BtnDeleteGetDataTableResponse> {                     
	@Resource                                                                                                       
	private Out1001Repository out1001Repository;                                                                    
	                                                                                                                
	@Override                    
	@Transactional(readOnly=true)
	public PHY2001U04BtnDeleteGetDataTableResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			PHY2001U04BtnDeleteGetDataTableRequest request) throws Exception {                                                                
  	   	PhysServiceProto.PHY2001U04BtnDeleteGetDataTableResponse.Builder response = PhysServiceProto.PHY2001U04BtnDeleteGetDataTableResponse.newBuilder();                      
		Double pkOut1001 = CommonUtils.parseDouble(request.getPkout1001());
		List<PHY2001U04BtnDeleteGetDataTableInfo> listDelete = out1001Repository.getPHY2001U04DeleteClickInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId),request.getBunho(), pkOut1001);
		if(!CollectionUtils.isEmpty(listDelete)){
			for(PHY2001U04BtnDeleteGetDataTableInfo item : listDelete){
				PhysModelProto.PHY2001U04BtnDeleteGetDataTableInfo.Builder info = PhysModelProto.PHY2001U04BtnDeleteGetDataTableInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				if (item.getPkout1001() != null) {
					info.setPkout1001(String.format("%.0f",item.getPkout1001()));
				}
				if (item.getPkocs1003() != null) {
					info.setPkocs1003(String.format("%.0f",item.getPkocs1003()));
				}
				if (item.getSinryouryouGubun() != null) {
					info.setSinryouryouGubun(String.format("%.0f",item.getSinryouryouGubun()));
				}
				response.addTblItem(info);
			}
		}
		return response.build();
	}
}