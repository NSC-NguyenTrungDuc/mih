package nta.med.service.ihis.handler.nuts;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.nut.Nut2011Repository;
import nta.med.data.model.ihis.nuts.NUT9001U00grdINP5001Info;
import nta.med.service.ihis.proto.NutsModelProto;
import nta.med.service.ihis.proto.NutsServiceProto;
import nta.med.service.ihis.proto.NutsServiceProto.NUT9001U00grdINP5001Request;
import nta.med.service.ihis.proto.NutsServiceProto.NUT9001U00grdINP5001Response;

@Service
@Scope("prototype")
public class NUT9001U00grdINP5001Handler extends
		ScreenHandler<NutsServiceProto.NUT9001U00grdINP5001Request, NutsServiceProto.NUT9001U00grdINP5001Response> {

	@Resource
	private Nut2011Repository nut2011Repository;

	@Override
	@Transactional(readOnly = true)
	public NUT9001U00grdINP5001Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUT9001U00grdINP5001Request request) throws Exception {
		NutsServiceProto.NUT9001U00grdINP5001Response.Builder response = NutsServiceProto.NUT9001U00grdINP5001Response.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);

		List<NUT9001U00grdINP5001Info> infos = nut2011Repository.getNUT9001U00grdINP5001Info(hospCode,
				DateUtil.toDate(request.getMagamDate(), DateUtil.PATTERN_YYMMDD));
		if (!CollectionUtils.isEmpty(infos)) {
			for (NUT9001U00grdINP5001Info info : infos) {
				NutsModelProto.NUT9001U00grdINP5001Info.Builder pInfo = NutsModelProto.NUT9001U00grdINP5001Info.newBuilder();
				BeanUtils.copyProperties(info, pInfo, language);
				if(StringUtils.isEmpty(info.getBSeq())){
					pInfo.setBSeq("0");
				}
				
				if(StringUtils.isEmpty(info.getLSeq())){
					pInfo.setLSeq("0");
				}
				
				if(StringUtils.isEmpty(info.getDSeq())){
					pInfo.setDSeq("0");
				}
				
				response.addGrdMasterItem(pInfo);
			}
		}

		return response.build();
	}

}
