package nta.med.service.ihis.handler.nuri;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.model.ihis.ocsa.DataStringListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR2004U00layMaxBedNoRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR2004U00layMaxBedNoResponse;
import nta.med.data.dao.medi.bas.Bas0250Repository;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class NUR2004U00layMaxBedNoHandler extends ScreenHandler<NuriServiceProto.NUR2004U00layMaxBedNoRequest, NuriServiceProto.NUR2004U00layMaxBedNoResponse> {
	@Resource
	private Bas0250Repository bas0250Repository;
	
	@Override
	@Transactional(readOnly=true)
	public NUR2004U00layMaxBedNoResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR2004U00layMaxBedNoRequest request) throws Exception {
		
		NuriServiceProto.NUR2004U00layMaxBedNoResponse.Builder response = NuriServiceProto.NUR2004U00layMaxBedNoResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		String hoDong = request.getHoDong();
		Date hoCodeYmd = DateUtil.toDate(request.getHoCodeYmd(), DateUtil.PATTERN_YYMMDD);
		
		List<DataStringListItemInfo> listInfo = bas0250Repository.getBAS0250Q00layMaxBedNoInfoList(hospCode, hoDong, hoCodeYmd);
		if(!CollectionUtils.isEmpty(listInfo)){
			for(DataStringListItemInfo item : listInfo){
				CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info,language);
				response.addMaxbedno(info);
			}
		}
		return response.build();
	}

}
