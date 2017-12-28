package nta.med.service.ihis.handler.system;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.common.annotation.Route;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.adm.Adm0000Repository;
import nta.med.data.dao.medi.out.OutsangRepository;
import nta.med.data.model.ihis.system.HospitalDetailInfo;
import nta.med.service.ihis.proto.SystemModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.GetHospitalListRequest;
import nta.med.service.ihis.proto.SystemServiceProto.GetHospitalListResponse;

@Service
@Scope("prototype")
public class GetHospitalListHandler extends ScreenHandler<SystemServiceProto.GetHospitalListRequest, SystemServiceProto.GetHospitalListResponse> {
	private static final Log LOGGER = LogFactory.getLog(GetHospitalListHandler.class);
	@Resource
	private OutsangRepository outsangRepository;
	
	@Resource
	private Adm0000Repository adm0000Repository;

	@Override
    @Transactional
    @Route(global = true)
	public GetHospitalListResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			GetHospitalListRequest request) throws Exception {
		
		SystemServiceProto.GetHospitalListResponse.Builder response = SystemServiceProto.GetHospitalListResponse.newBuilder();	
		Date startDate = new Date();
		
		String hospNameConverted = adm0000Repository.callFnAdmConvertKanaFull(getHospitalCode(vertx, sessionId) , request.getHospName());
		String addressConverted = adm0000Repository.callFnAdmConvertKanaFull(getHospitalCode(vertx, sessionId) , request.getAddress());
		
		List<HospitalDetailInfo> hospList = outsangRepository.getHospitalList(request.getHospName(), request.getAddress(), request.getTel(), request.getCountryCode(), hospNameConverted, addressConverted); 		
		LOGGER.info("Time: =" +  (new Date().getTime() - startDate.getTime()));
		if (!CollectionUtils.isEmpty(hospList)) {
            for (HospitalDetailInfo item : hospList) {
            	SystemModelProto.HospitalDetailInfo.Builder info = SystemModelProto.HospitalDetailInfo.newBuilder();
                BeanUtils.copyProperties(item, info, "JA");
                response.addItemInfo(info.build());
            }
        }
		
		return response.build();
	}

}
