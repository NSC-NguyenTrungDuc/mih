package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class NuroRES0102U00CboGwaHandler extends ScreenHandler<NuroServiceProto.NuroRES0102U00CboGwaRequest, NuroServiceProto.NuroRES0102U00CboGwaResponse>{
private static final Log logger = LogFactory.getLog(NuroRES0102U00CboGwaHandler.class);
	
	@Resource
	private Bas0260Repository bas0260Repository;
	
	@Override
	public boolean isValid(NuroServiceProto.NuroRES0102U00CboGwaRequest request, Vertx vertx, String clientId, String sessionId) {
        if (!StringUtils.isEmpty(request.getAppDate())&& DateUtil.toDate(request.getAppDate(),DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}

	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroRES0102U00CboGwaResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroRES0102U00CboGwaRequest request) throws Exception {
        NuroServiceProto.NuroRES0102U00CboGwaResponse.Builder response = NuroServiceProto.NuroRES0102U00CboGwaResponse.newBuilder();
        String hospCode = request.getHospCode();
        if(!StringUtils.isEmpty(request.getHospCodeLink())){
        	hospCode = request.getHospCodeLink();
        }
        List<ComboListItemInfo> listNuroRES0102U00CboGwa = bas0260Repository.getNuroRES0102U00CboGwa(getLanguage(vertx, sessionId), hospCode, request.getAppDate());
        if (listNuroRES0102U00CboGwa != null && !listNuroRES0102U00CboGwa.isEmpty()) {
            for (ComboListItemInfo obj : listNuroRES0102U00CboGwa) {
                CommonModelProto.ComboListItemInfo.Builder builder = CommonModelProto.ComboListItemInfo.newBuilder();
                if(!StringUtils.isEmpty(obj.getCode())) {
                	builder.setCode(obj.getCode());
                }
                if(!StringUtils.isEmpty(obj.getCodeName())) {
                	builder.setCodeName(obj.getCodeName());
                }
                
                response.addCboItemInfo(builder);
            }
        }
		return response.build();
	}
}
