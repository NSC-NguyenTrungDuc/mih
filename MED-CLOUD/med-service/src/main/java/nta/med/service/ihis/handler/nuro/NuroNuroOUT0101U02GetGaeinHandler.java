package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0111Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.lang3.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;


@Service
@Scope("prototype")
public class NuroNuroOUT0101U02GetGaeinHandler extends ScreenHandler<NuroServiceProto.NuroNuroOUT0101U02GetGaeinRequest, NuroServiceProto.NuroNuroOUT0101U02GetGaeinResponse>{
	private static final Log LOGGER = LogFactory.getLog(NuroNuroOUT0101U02GetGaeinHandler.class);
	@Resource
	private Bas0111Repository bas0111Repository;
		
	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroNuroOUT0101U02GetGaeinResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroNuroOUT0101U02GetGaeinRequest request) throws Exception {
		NuroServiceProto.NuroNuroOUT0101U02GetGaeinResponse.Builder response = NuroServiceProto.NuroNuroOUT0101U02GetGaeinResponse.newBuilder();
		List<String> nuroOUT0101U02GetGaeinList = bas0111Repository.getNuroNuroOUT0101U02GetGaein(getHospitalCode(vertx, sessionId), request.getJohap(), request.getGaein());
		if(!CollectionUtils.isEmpty(nuroOUT0101U02GetGaeinList)){
			for (String gaein : nuroOUT0101U02GetGaeinList) {
				if (!StringUtils.isEmpty(gaein)) {
					CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
					response.addGaeinList(info.setDataValue(gaein));
				}
			}
		}
		return response.build();
	}

}
