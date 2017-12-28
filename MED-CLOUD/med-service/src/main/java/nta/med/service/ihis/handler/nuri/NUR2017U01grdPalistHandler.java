package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs2017Repository;
import nta.med.data.model.ihis.nuri.NUR2017U01grdPalistInfo;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR2017U01grdPalistRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR2017U01grdPalistResponse;

@Service
@Scope("prototype")
public class NUR2017U01grdPalistHandler extends
		ScreenHandler<NuriServiceProto.NUR2017U01grdPalistRequest, NuriServiceProto.NUR2017U01grdPalistResponse> {

	@Resource
	private Ocs2017Repository ocs2017Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NUR2017U01grdPalistResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR2017U01grdPalistRequest request) throws Exception {
		
		NuriServiceProto.NUR2017U01grdPalistResponse.Builder response = NuriServiceProto.NUR2017U01grdPalistResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		String offset = request.getOffset();
        Integer startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), offset);
		
		List<NUR2017U01grdPalistInfo> items = ocs2017Repository.getNUR2017U01grdPalistInfo(hospCode,
				request.getHoDong(), request.getOrderGubun(), request.getActResDate(), request.getA(), request.getB(), request.getC(), request.getD(),
				startNum, CommonUtils.parseInteger(offset));
        
		for (NUR2017U01grdPalistInfo item : items) {
			NuriModelProto.NUR2017U01grdPalistInfo.Builder info = NuriModelProto.NUR2017U01grdPalistInfo.newBuilder();
			BeanUtils.copyProperties(item, info, language);
			response.addItems(info);
		}
		
		return response.build();
	}

}
