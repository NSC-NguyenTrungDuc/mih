package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.res.Res0102Repository;
import nta.med.data.model.ihis.nuro.RES1001U00FrmModifyReserGrdRES1001Info;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class RES1001U00FrmModifyReserGrdRES1001Handler  extends ScreenHandler<NuroServiceProto.RES1001U00FrmModifyReserGrdRES1001Request, NuroServiceProto.RES1001U00FrmModifyReserGrdRES1001Response> {
	private static final Log LOG = LogFactory.getLog(RES1001U00FrmModifyReserGrdRES1001Handler.class);
	
	@Resource
	private Res0102Repository res0102Repository;
	
	@Override
	public boolean isValid(NuroServiceProto.RES1001U00FrmModifyReserGrdRES1001Request request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getDate()) && DateUtil.toDate(request.getDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}

	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.RES1001U00FrmModifyReserGrdRES1001Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.RES1001U00FrmModifyReserGrdRES1001Request request) throws Exception {
		NuroServiceProto.RES1001U00FrmModifyReserGrdRES1001Response.Builder response = NuroServiceProto.RES1001U00FrmModifyReserGrdRES1001Response.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		if(!StringUtils.isEmpty(request.getHospCodeLink())){
			hospCode = request.getHospCodeLink();
		}
		List<RES1001U00FrmModifyReserGrdRES1001Info> listItem = res0102Repository.getRES1001U00FrmModifyReserGrdRES1001Info(request.getDayOfWeek(), hospCode, request.getDoctor(), request.getDate());
    	if (!CollectionUtils.isEmpty(listItem)) {
        	 for (RES1001U00FrmModifyReserGrdRES1001Info item : listItem) {
        		 NuroModelProto.RES1001U00FrmModifyReserGrdRES1001Info.Builder info = NuroModelProto.RES1001U00FrmModifyReserGrdRES1001Info.newBuilder();
        		 BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
        		 response.addGrdRes1001Info(info);
             }
    	}
		return response.build();
	}
}
