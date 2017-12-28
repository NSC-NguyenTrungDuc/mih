package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.common.annotation.Route;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.out.Out0102Repository;
import nta.med.data.model.ihis.nuro.NuroOUT1001U01GetTypeInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto;
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
public class NuroOUT1001U01GetTypeHandler extends ScreenHandler<NuroServiceProto.NuroOUT1001U01GetTypeRequest, NuroServiceProto.NuroOUT1001U01GetTypeResponse>{
private static final Log logger = LogFactory.getLog(NuroOUT1001U01GetTypeHandler.class);
	
	@Resource
	private Out0102Repository out0102Repository;
	
	@Override
	public boolean isValid(NuroServiceProto.NuroOUT1001U01GetTypeRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getNaewonDate()) && DateUtil.toDate(request.getNaewonDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}
	
	@Override
	@Transactional(readOnly = true)
	@Route(global = false)
	public NuroServiceProto.NuroOUT1001U01GetTypeResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroOUT1001U01GetTypeRequest request) throws Exception {
		List<NuroOUT1001U01GetTypeInfo> listNuroOUT1001U01GetTypeInfo = out0102Repository.getNuroOUT1001U01GetTypeInfo(getHospitalCode(vertx, sessionId), request.getBunho(), 
				request.getNaewonDate(), request.getFind1(), getLanguage(vertx, sessionId));
        NuroServiceProto.NuroOUT1001U01GetTypeResponse.Builder response= NuroServiceProto.NuroOUT1001U01GetTypeResponse.newBuilder();
        if (listNuroOUT1001U01GetTypeInfo != null && !listNuroOUT1001U01GetTypeInfo.isEmpty()) {
            for (NuroOUT1001U01GetTypeInfo item : listNuroOUT1001U01GetTypeInfo) {
                NuroModelProto.NuroOUT1001U01GetTypeInfo.Builder builder = NuroModelProto.NuroOUT1001U01GetTypeInfo.newBuilder();
                if(!StringUtils.isEmpty(item.getGubun())) {
                	builder.setGubun(item.getGubun());
            	}
                if(!StringUtils.isEmpty(item.getGubunName())) {
                	builder.setGubunName(item.getGubunName());
            	}
                if(!StringUtils.isEmpty(item.getLastCheckDate())) {
                	builder.setLastCheckDate(item.getLastCheckDate());
            	}
                if(!StringUtils.isEmpty(item.getLastCheckDate())) {
                	builder.setLastCheckDate(item.getLastCheckDate());
            	}
                response.addTypeItem(builder);
            }
        }
		return response.build();
	}

}
