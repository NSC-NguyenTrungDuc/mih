package nta.med.service.ihis.handler.injs;

import java.util.ArrayList;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.inj.Inj1002Repository;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.dao.medi.sch.Sch0201Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.InjsModelProto.INJ1002U01GrdOrderListItemInfo;
import nta.med.service.ihis.proto.InjsServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Transactional
@Service
@Scope("prototype")
public class INJ1002U01SaveLayoutHandler extends ScreenHandler<InjsServiceProto.INJ1002U01SaveLayoutRequest, SystemServiceProto.UpdateResponse> {
	private static final Log LOG =  LogFactory.getLog(INJ1002U01SaveLayoutHandler.class);
	@Resource
	private Inj1002Repository inj1002Repository;
	@Resource
	private Ocs1003Repository ocs1003Repository;
	@Resource
	private Out1001Repository out1001Repository;
	@Resource
	private Sch0201Repository sch0201Repository;
	
	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			InjsServiceProto.INJ1002U01SaveLayoutRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		for(INJ1002U01GrdOrderListItemInfo inputInfo : request.getGrdOrderInfoList()){
			boolean updateReserData = updateReserDataNotInj(inputInfo, hospCode);
			String ioFlag = "";
			List<Double> listC1 = inj1002Repository.getFkocs1003(hospCode, inputInfo.getPkinj1002());
			for(Double fkOcs1003 : listC1){
				List<String> listResult = ocs1003Repository.callPrOcsUpdateHopeDate(hospCode, "O", fkOcs1003, inputInfo.getReserDate(), "", "");
				ioFlag = listResult.get(0).toString();
				if(!ioFlag.equalsIgnoreCase("0")){
					response.setResult(false);
					throw new ExecutionException(response.build());
				}
			}
			if(updateReserData && ioFlag.equalsIgnoreCase("0")){
				response.setResult(true);
			}
		}
		return response.build();
	}

	private boolean updateReserDataNotInj(INJ1002U01GrdOrderListItemInfo item, String hospCode) {
		List<Double> pkinj = new ArrayList<Double>();
		pkinj.add(CommonUtils.parseDouble(item.getPkinj1002()));
		if(inj1002Repository.updatReserDate(item.getReserDate(), hospCode, pkinj) > 0){
			return true;
		}else{
			return false;
		}
	}
}
