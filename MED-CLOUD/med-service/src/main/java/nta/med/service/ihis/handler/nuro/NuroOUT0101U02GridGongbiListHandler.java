package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.model.ihis.nuro.NuroOUT0101U02GridGongbiListInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class NuroOUT0101U02GridGongbiListHandler extends ScreenHandler<NuroServiceProto.NuroOUT0101U02GridGongbiListRequest, NuroServiceProto.NuroOUT0101U02GridGongbiListResponse>{
	private static final Log LOGGER = LogFactory.getLog(NuroOUT0101U02GridGongbiListHandler.class);
	@Resource
	private Out0101Repository out0101Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroOUT0101U02GridGongbiListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroOUT0101U02GridGongbiListRequest request) throws Exception {
		NuroServiceProto.NuroOUT0101U02GridGongbiListResponse.Builder response = NuroServiceProto.NuroOUT0101U02GridGongbiListResponse.newBuilder();
		List<NuroOUT0101U02GridGongbiListInfo> listNuroOUT0101U02GridGongbiListInfo = out0101Repository.getNuroOUT0101U02GridGongbiListInfo(getHospitalCode(vertx, sessionId), 
				request.getPatientCode(), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listNuroOUT0101U02GridGongbiListInfo)){
			for(NuroOUT0101U02GridGongbiListInfo item : listNuroOUT0101U02GridGongbiListInfo){
				NuroModelProto.NuroOUT0101U02GridGongbiListInfo.Builder nuroGridGongbiListInfo = NuroModelProto.NuroOUT0101U02GridGongbiListInfo.newBuilder();
				BeanUtils.copyProperties(item, nuroGridGongbiListInfo, getLanguage(vertx, sessionId));
				response.addGridGongbiListItem(nuroGridGongbiListInfo);
			}	
		}
		return response.build();
	}
}
