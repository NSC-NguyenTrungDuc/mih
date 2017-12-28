package nta.med.service.ihis.handler.nuro;

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
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroServiceProto;

@Service
@Scope("prototype")
public class NuroRES0102U00ChkHyujinHandler extends ScreenHandler<NuroServiceProto.NuroRES0102U00ChkHyujinRequest, NuroServiceProto.NuroRES0102U00ChkHyujinResponse>{
private static final Log logger = LogFactory.getLog(NuroRES0102U00ChkHyujinHandler.class);
	
	@Resource
	private Out1001Repository out1001Repository;
	
	@Override
	public boolean isValid(NuroServiceProto.NuroRES0102U00ChkHyujinRequest request, Vertx vertx, String clientId, String sessionId) {
        if (!StringUtils.isEmpty(request.getStartDate())&& DateUtil.toDate(request.getStartDate(),DateUtil.PATTERN_YYMMDD) == null) {
        	return false;
		} else if (!StringUtils.isEmpty(request.getEndDate())&& DateUtil.toDate(request.getEndDate(),DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		} 
		return true;
	}

	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, NuroServiceProto.NuroRES0102U00ChkHyujinRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroRES0102U00ChkHyujinResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroRES0102U00ChkHyujinRequest request) throws Exception {
        NuroServiceProto.NuroRES0102U00ChkHyujinResponse.Builder response = NuroServiceProto.NuroRES0102U00ChkHyujinResponse.newBuilder();
        String strNuroRES0102U00ChkHyujin = out1001Repository.getNuroRES0102U00ChkHyujin(request.getHospCode(), request.getDoctor(), request.getStartDate(), request.getEndDate());
        if(!StringUtils.isEmpty(strNuroRES0102U00ChkHyujin)) {
           response.setCheck(strNuroRES0102U00ChkHyujin);
        }
		return response.build();
	}
}
