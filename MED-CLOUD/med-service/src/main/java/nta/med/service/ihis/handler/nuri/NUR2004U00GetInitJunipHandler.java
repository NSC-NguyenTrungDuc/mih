package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.inp.Inp2004Repository;
import nta.med.data.model.ihis.nuri.NUR2004U00GetInitJunipInfo;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR2004U00GetInitJunipRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR2004U00GetInitJunipResponse;

@Service                                                                                                          
@Scope("prototype")
public class NUR2004U00GetInitJunipHandler extends ScreenHandler<NuriServiceProto.NUR2004U00GetInitJunipRequest, NuriServiceProto.NUR2004U00GetInitJunipResponse> {
	@Resource
	private Inp2004Repository inp2004Repository;
	
	@Override
	@Transactional(readOnly=true)
	public NUR2004U00GetInitJunipResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR2004U00GetInitJunipRequest request) throws Exception {
		NuriServiceProto.NUR2004U00GetInitJunipResponse.Builder response = NuriServiceProto.NUR2004U00GetInitJunipResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		Double fkinp1001 = CommonUtils.parseDouble(request.getFkinp1001());
		String hoDong = request.getHodong();
		String date = request.getDate();
		
		List<NUR2004U00GetInitJunipInfo> listInfo = inp2004Repository.getNUR2004U00GetInitJunip(hospCode, language, fkinp1001, hoDong, date);
		if(!CollectionUtils.isEmpty(listInfo)){
			for(NUR2004U00GetInitJunipInfo item : listInfo){
				NuriModelProto.NUR2004U00GetInitJunipInfo.Builder info = NuriModelProto.NUR2004U00GetInitJunipInfo.newBuilder();
				BeanUtils.copyProperties(item, info,language);
				response.addListGetinit(info);
			}
		}
		return response.build();
	}

}
