package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.res.Res0106Repository;
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
public class CboAvgTimeHandler extends ScreenHandler<NuroServiceProto.CboAvgTimeRequest, NuroServiceProto.CboAvgTimeResponse>{
private static final Log logger = LogFactory.getLog(CboAvgTimeHandler.class);
	
	@Resource
	private Res0106Repository res0106Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.CboAvgTimeResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.CboAvgTimeRequest request) throws Exception {
        NuroServiceProto.CboAvgTimeResponse.Builder response = NuroServiceProto.CboAvgTimeResponse.newBuilder();
        List<String> listCboAvgTime = res0106Repository.getCboAvgTime();
        if (listCboAvgTime != null && !listCboAvgTime.isEmpty()) {
            for (String obj : listCboAvgTime) {
                NuroModelProto.CboAvgTimeInfo.Builder builder = NuroModelProto.CboAvgTimeInfo.newBuilder();
                if(!StringUtils.isEmpty(obj)) {
                	builder.setTimeTerm(obj);
                	builder.setTimeTerm2(obj);
                }
                response.addAvgTimeItem(builder);
            }
        }
		return response.build();
	}
}
