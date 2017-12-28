package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.res.Res0102Repository;
import nta.med.data.model.ihis.nuro.NuroRES0102U00GrdRES0102Info;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class NuroRES0102U00GrdRES0102Handler extends ScreenHandler<NuroServiceProto.NuroRES0102U00GrdRES0102Request, NuroServiceProto.NuroRES0102U00GrdRES0102Response>{
	private static final Log logger = LogFactory.getLog(NuroRES0102U00GrdRES0102Handler.class);
	
	@Resource
	private Res0102Repository res0102Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroRES0102U00GrdRES0102Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroRES0102U00GrdRES0102Request request) throws Exception {
        NuroServiceProto.NuroRES0102U00GrdRES0102Response.Builder response = NuroServiceProto.NuroRES0102U00GrdRES0102Response.newBuilder();
        List<NuroRES0102U00GrdRES0102Info> listNuroRES0102U00GrdRES0102Info = res0102Repository.getNuroRES0102U00GrdRES0102Info(request.getHospCode(), request.getDoctor());
        if (listNuroRES0102U00GrdRES0102Info != null && !listNuroRES0102U00GrdRES0102Info.isEmpty()) {
            for (NuroRES0102U00GrdRES0102Info item : listNuroRES0102U00GrdRES0102Info) {
                NuroModelProto.NuroRES0102U00GrdRES0102Info.Builder info = NuroModelProto.NuroRES0102U00GrdRES0102Info.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addGridInfoList(info);
            }
        }
		return response.build();
    }
}
