package nta.med.service.ihis.handler.nuri;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR2004U00layHoSexRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;
import nta.med.data.dao.medi.bas.Bas0250Repository;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;


@Service                                                                                                          
@Scope("prototype")
public class NUR2004U00layHoSexHandler extends ScreenHandler<NuriServiceProto.NUR2004U00layHoSexRequest, SystemServiceProto.ComboResponse> {
	@Resource
	private Bas0250Repository bas0250Repository;
	
	@Override
	@Transactional(readOnly=true)
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR2004U00layHoSexRequest request) throws Exception {
		ComboResponse.Builder response = ComboResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		String hoCode = request.getHoCode();
		String hoDong = request.getHoDong();
		Date date = DateUtil.toDate(request.getDate(), DateUtil.PATTERN_YYMMDD);
		
		List<ComboListItemInfo> listInfo = bas0250Repository.getNUR2004U00layHoSex(hospCode, hoCode, hoDong, date);
		if(!CollectionUtils.isEmpty(listInfo)){
			for(ComboListItemInfo item : listInfo){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info,language);
				response.addComboItem(info);
			}
		}
		return response.build();
	}

}
