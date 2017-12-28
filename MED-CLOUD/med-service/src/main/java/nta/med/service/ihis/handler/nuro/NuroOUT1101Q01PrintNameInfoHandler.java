package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.model.ihis.nuro.NuroOUT1101Q01PrintNameInfo;
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
public class NuroOUT1101Q01PrintNameInfoHandler extends ScreenHandler<NuroServiceProto.NuroOUT1101Q01PrintNameInfoRequest, NuroServiceProto.NuroOUT1101Q01PrintNameInfoResponse>{
	private static final Log logger = LogFactory.getLog(NuroOUT1101Q01PrintNameInfoHandler.class);
	
	@Resource
	private Bas0102Repository bas0102Repository;

	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroOUT1101Q01PrintNameInfoResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroOUT1101Q01PrintNameInfoRequest  request) throws Exception {
		List<NuroOUT1101Q01PrintNameInfo> listNuroOUT1101Q01PrintNameInfo = bas0102Repository.getNuroOUT1101Q01PrintNameInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId));
        NuroServiceProto.NuroOUT1101Q01PrintNameInfoResponse.Builder response = NuroServiceProto.NuroOUT1101Q01PrintNameInfoResponse.newBuilder();
        if (listNuroOUT1101Q01PrintNameInfo != null && !listNuroOUT1101Q01PrintNameInfo.isEmpty()) {
            for (NuroOUT1101Q01PrintNameInfo obj : listNuroOUT1101Q01PrintNameInfo) {
                NuroModelProto.NuroOUT1101Q01PrintNameInfo.Builder builder = NuroModelProto.NuroOUT1101Q01PrintNameInfo.newBuilder();
                if(!StringUtils.isEmpty(obj.getCodeName())) {
                	builder.setCodeName(obj.getCodeName());
                }
                if(!StringUtils.isEmpty(obj.getSortKey())) {
                	builder.setSortKey(obj.getSortKey());
                }
                response.addPrintNameInfoList(builder);
            }
        }
		return response.build();
	}

}
