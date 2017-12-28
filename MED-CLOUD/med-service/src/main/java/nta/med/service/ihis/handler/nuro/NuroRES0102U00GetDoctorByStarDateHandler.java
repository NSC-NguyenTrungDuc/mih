package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.glossary.UserRole;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.res.Res0104Repository;
import nta.med.data.model.ihis.nuro.NuroRES0102U00GetDoctorInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

@Service
@Scope("prototype")
public class NuroRES0102U00GetDoctorByStarDateHandler  extends ScreenHandler<NuroServiceProto.NuroRES0102U00GetDoctorByStarDateRequest, NuroServiceProto.NuroRES0102U00GetDoctorResponse>{
private static final Log logger = LogFactory.getLog(NuroRES0102U00GetDoctorByStarDateHandler.class);
	
	@Resource
	private Res0104Repository res0104Repository;
	
	@Override
	public boolean isValid(NuroServiceProto.NuroRES0102U00GetDoctorByStarDateRequest request, Vertx vertx, String clientId, String sessionId) {
        if (!StringUtils.isEmpty(request.getStartDate())&& DateUtil.toDate(request.getStartDate(),DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}
	
	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, NuroServiceProto.NuroRES0102U00GetDoctorByStarDateRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroRES0102U00GetDoctorResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroRES0102U00GetDoctorByStarDateRequest request) throws Exception {
        NuroServiceProto.NuroRES0102U00GetDoctorResponse.Builder response = NuroServiceProto.NuroRES0102U00GetDoctorResponse.newBuilder();
        List<NuroRES0102U00GetDoctorInfo> listNuroRES0102U00GetDoctorByStarDate = res0104Repository.getNuroRES0102U00GetDoctorByStarDate(request.getHospCode(),
        		request.getDoctor(), request.getStartDate());
        if (listNuroRES0102U00GetDoctorByStarDate != null && !listNuroRES0102U00GetDoctorByStarDate.isEmpty()) {
            for (NuroRES0102U00GetDoctorInfo obj : listNuroRES0102U00GetDoctorByStarDate) {
                NuroModelProto.NuroRES0102U00GetDoctorInfo.Builder builder = NuroModelProto.NuroRES0102U00GetDoctorInfo.newBuilder();
                if(!StringUtils.isEmpty(obj.getDoctor())) {
                	builder.setDoctor(obj.getDoctor());
                }
                response.addDoctorItem(builder);
            }
        }
		return response.build();
	}	

}
