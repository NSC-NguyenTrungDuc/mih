package nta.med.service.ihis.handler.nuts;

import java.util.ArrayList;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.dao.medi.ocs.Ocs2003Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NutsServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class NUT0001U00LoadDoctorGwaHandler extends ScreenHandler<NutsServiceProto.NUT0001U00LoadDoctorGwaRequest, NutsServiceProto.NUT0001U00LoadDoctorGwaResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(NUT0001U00LoadDoctorGwaHandler.class);                                    
	@Resource                                                                                                       
	private Ocs1003Repository ocs1003Repository;     
	@Resource                                                                                                       
	private Ocs2003Repository ocs2003Repository;  

	@Override
	@Transactional(readOnly = true)
	public NutsServiceProto.NUT0001U00LoadDoctorGwaResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NutsServiceProto.NUT0001U00LoadDoctorGwaRequest request) throws Exception {
		NutsServiceProto.NUT0001U00LoadDoctorGwaResponse.Builder response = NutsServiceProto.NUT0001U00LoadDoctorGwaResponse.newBuilder(); 
		String hospCode = getHospitalCode(vertx, sessionId);
		List<ComboListItemInfo> listDoctorGwaInfo = new ArrayList<ComboListItemInfo>();
		    if(request.getInOutGubun().equalsIgnoreCase("O")){
		    	listDoctorGwaInfo = ocs1003Repository.getNut0001U00InitializeScreenOcs1003DoctorGwaInfo(hospCode, CommonUtils.parseDouble(request.getPkocskey()));
		    }else{
		    	listDoctorGwaInfo = ocs2003Repository.getNut0001U00InitializeScreenOcs0203DoctorGwaInfo(hospCode, CommonUtils.parseDouble(request.getPkocskey()));
		    }
		    
		    if(!CollectionUtils.isEmpty(listDoctorGwaInfo)){
		    	for(ComboListItemInfo item : listDoctorGwaInfo){
		    		CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
		    		BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
		    		response.addDoctorGwaInfo(info);
		    	}
		    }
		return response.build();
	}                                                                                                                 
}