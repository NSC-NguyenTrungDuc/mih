package nta.med.service.ihis.handler.bill;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.BillServiceProto;
import nta.med.service.ihis.proto.BillServiceProto.BIL2016R01CboAllRequest;
import nta.med.service.ihis.proto.BillServiceProto.BIL2016R01CboAllResponse;
import nta.med.service.ihis.proto.CommonModelProto;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class BIL2016R01CboAllHandler extends ScreenHandler<BillServiceProto.BIL2016R01CboAllRequest, BillServiceProto.BIL2016R01CboAllResponse>{
	private static final Log LOGGER = LogFactory.getLog(BIL2016R01CboAllHandler.class);

	@Resource                                                                                                       
	private Bas0260Repository bas0260Repository; 
	
	@Override
	@Transactional(readOnly = true)
	public BIL2016R01CboAllResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, BIL2016R01CboAllRequest request)
			throws Exception{                                                                   
		BillServiceProto.BIL2016R01CboAllResponse.Builder response = BillServiceProto.BIL2016R01CboAllResponse.newBuilder();                      
		List<ComboListItemInfo> listAssignDept = bas0260Repository.getAssignDeptCombo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listAssignDept)){
			for(ComboListItemInfo item:listAssignDept){
				CommonModelProto.ComboListItemInfo.Builder info= CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addCboAssignDept(info);
			}
			List<ComboListItemInfo> listExeDept = listAssignDept;
			for(ComboListItemInfo item:listExeDept){
				CommonModelProto.ComboListItemInfo.Builder info= CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addCboExeDept(info);
			}
		}
		
		return response.build();
	}
}