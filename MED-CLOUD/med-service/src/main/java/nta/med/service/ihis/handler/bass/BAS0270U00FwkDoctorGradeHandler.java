package nta.med.service.ihis.handler.bass;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.bas.Bas0102;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0270U00FwkDoctorGradeRequest;
import nta.med.service.ihis.proto.BassServiceProto.BAS0270U00FwkDoctorGradeResponse;
import nta.med.service.ihis.proto.CommonModelProto;

@Service                                                                                                          
@Scope("prototype")
public class BAS0270U00FwkDoctorGradeHandler extends ScreenHandler<BassServiceProto.BAS0270U00FwkDoctorGradeRequest, BassServiceProto.BAS0270U00FwkDoctorGradeResponse> {                             
	private static final Log LOG = LogFactory.getLog(BAS0270U00FwkDoctorGradeHandler.class);                                        
	
	@Resource                                                                                                       
	private Bas0102Repository bas0102Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public BAS0270U00FwkDoctorGradeResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			BAS0270U00FwkDoctorGradeRequest request) throws Exception {                                                                   
		BassServiceProto.BAS0270U00FwkDoctorGradeResponse.Builder response = BassServiceProto.BAS0270U00FwkDoctorGradeResponse.newBuilder();
		
		List<Bas0102> listBas0102 = bas0102Repository.getByCodeAndCodeNameAndCodeType(getHospitalCode(vertx, sessionId), request.getCode() + "%", request.getFind1() + "%", getLanguage(vertx, sessionId));
		
		if(!CollectionUtils.isEmpty(listBas0102)) {
			for (Bas0102 item : listBas0102) {
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				if(!StringUtils.isEmpty(item.getCode())) {
					info.setCode(item.getCode());
				}
				if(!StringUtils.isEmpty(item.getCodeName())) {
					info.setCodeName(item.getCodeName());
				}
				response.addFwkList(info);
			}
		}
		
		return response.build();
	}
}                                                                                                                 
