package nta.med.service.ihis.handler.drgs;

import nta.med.data.dao.medi.drg.Drg1000Repository;
import nta.med.data.model.ihis.drgs.DrgsDRG5100P01AntiDataListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.DrgsModelProto;
import nta.med.service.ihis.proto.DrgsServiceProto;
import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import java.util.List;

@Service
@Scope("prototype")
public class DrgsDRG5100P01AntiDataListHandler extends ScreenHandler<DrgsServiceProto.DrgsDRG5100P01AntiDataListRequest, DrgsServiceProto.DrgsDRG5100P01AntiDataListResponse> {
	private static final Log LOG = LogFactory.getLog(DrgsDRG5100P01AntiDataListHandler.class);
	@Resource
	private Drg1000Repository drg1000Repository;

	@Override
	@Transactional(readOnly = true)
	public DrgsServiceProto.DrgsDRG5100P01AntiDataListResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DrgsDRG5100P01AntiDataListRequest request) throws Exception {
		DrgsServiceProto.DrgsDRG5100P01AntiDataListResponse.Builder response = DrgsServiceProto.DrgsDRG5100P01AntiDataListResponse.newBuilder();
		List<DrgsDRG5100P01AntiDataListItemInfo> listObject = drg1000Repository.getDrgsDRG5100P01OrderListItemInfo(getHospitalCode(vertx, sessionId), request.getFkocs());
		if(!CollectionUtils.isEmpty(listObject)) {
			for(DrgsDRG5100P01AntiDataListItemInfo item : listObject) {
				DrgsModelProto.DrgsDRG5100P01AntiDataListItemInfo.Builder info = DrgsModelProto.DrgsDRG5100P01AntiDataListItemInfo.newBuilder();
				if (!StringUtils.isEmpty(item.getFkocs())) {
					info.setFkocs(item.getFkocs());
				}
				if (!StringUtils.isEmpty(item.getInOutGubun())) {
					info.setInOutGubun(item.getInOutGubun());
				}
				if (!StringUtils.isEmpty(item.getOrderDate())) {
					info.setOrderDate(item.getOrderDate());
				}
				if (!StringUtils.isEmpty(item.getBunho())) {
					info.setBunho(item.getBunho());
				}
				if (!StringUtils.isEmpty(item.getGwa())) {
					info.setGwa(item.getGwa());
				}
				if (!StringUtils.isEmpty(item.getDoctor())) {
					info.setDoctor(item.getDoctor());
				}
				if (!StringUtils.isEmpty(item.getHoDong())) {
					info.setHoDong(item.getHoDong());
				}
				if (!StringUtils.isEmpty(item.getIpwonDate())) {
					info.setIpwonDate(item.getIpwonDate());
				}
				if (!StringUtils.isEmpty(item.getJubsuDate())) {
					info.setJubsuDate(item.getJubsuDate());
				}
				if (!StringUtils.isEmpty(item.getV1())) {
					info.setV1(item.getV1());
				}
				if (!StringUtils.isEmpty(item.getV2())) {
					info.setV2(item.getV2());
				}
				if (!StringUtils.isEmpty(item.getV3())) {
					info.setV3(item.getV3());
				}
				if (!StringUtils.isEmpty(item.getV4())) {
					info.setV4(item.getV4());
				}
				if (!StringUtils.isEmpty(item.getV5())) {
					info.setV5(item.getV5());
				}
				if (!StringUtils.isEmpty(item.getV6())) {
					info.setV6(item.getV6());
				}
				if (!StringUtils.isEmpty(item.getV7())) {
					info.setV7(item.getV7());
				}
				if (!StringUtils.isEmpty(item.getV8())) {
					info.setV8(item.getV8());
				}
				if (!StringUtils.isEmpty(item.getV9())) {
					info.setV9(item.getV9());
				}
				if (!StringUtils.isEmpty(item.getCheck01())) {
					info.setCheck01(item.getCheck01());
				}
				if (!StringUtils.isEmpty(item.getCheck02())) {
					info.setCheck02(item.getCheck02());
				}
				if (!StringUtils.isEmpty(item.getCheck03())) {
					info.setCheck03(item.getCheck03());
				}
				if (!StringUtils.isEmpty(item.getCheck04())) {
					info.setCheck04(item.getCheck04());
				}
				if (!StringUtils.isEmpty(item.getCheck05())) {
					info.setCheck05(item.getCheck05());
				}
				if (!StringUtils.isEmpty(item.getCheck06())) {
					info.setCheck06(item.getCheck06());
				}
				if (!StringUtils.isEmpty(item.getCheck07())) {
					info.setCheck07(item.getCheck07());
				}
				if (!StringUtils.isEmpty(item.getCheck08())) {
					info.setCheck08(item.getCheck08());
				}
				if (!StringUtils.isEmpty(item.getCheck09())) {
					info.setCheck09(item.getCheck09());
				}
				if (!StringUtils.isEmpty(item.getCheck10())) {
					info.setCheck10(item.getCheck10());
				}
				if (!StringUtils.isEmpty(item.getCheck11())) {
					info.setCheck11(item.getCheck11());
				}
				if (!StringUtils.isEmpty(item.getCheck12())) {
					info.setCheck12(item.getCheck12());
				}
				if (!StringUtils.isEmpty(item.getCheck13())) {
					info.setCheck13(item.getCheck13());
				}
				if (!StringUtils.isEmpty(item.getCheck14())) {
					info.setCheck14(item.getCheck14());
				}
				if (!StringUtils.isEmpty(item.getCheck15())) {
					info.setCheck15(item.getCheck15());
				}
				if (!StringUtils.isEmpty(item.getCheck16())) {
					info.setCheck16(item.getCheck16());
				}
				if (!StringUtils.isEmpty(item.getCheck17())) {
					info.setCheck17(item.getCheck17());
				}
				if (!StringUtils.isEmpty(item.getCheck18())) {
					info.setCheck18(item.getCheck18());
				}
				if (!StringUtils.isEmpty(item.getCheck19())) {
					info.setCheck19(item.getCheck19());
				}
				if (!StringUtils.isEmpty(item.getCheck20())) {
					info.setCheck20(item.getCheck20());
				}
				if (!StringUtils.isEmpty(item.getCheck21())) {
					info.setCheck21(item.getCheck21());
				}
				if (!StringUtils.isEmpty(item.getCheck22())) {
					info.setCheck22(item.getCheck22());
				}
				if (!StringUtils.isEmpty(item.getCheck23())) {
					info.setCheck23(item.getCheck23());
				}
				if (!StringUtils.isEmpty(item.getCheck24())) {
					info.setCheck24(item.getCheck24());
				}
				if (!StringUtils.isEmpty(item.getCheck25())) {
					info.setCheck25(item.getCheck25());
				}
				if (!StringUtils.isEmpty(item.getCheck26())) {
					info.setCheck26(item.getCheck26());
				}
				if (!StringUtils.isEmpty(item.getCheck27())) {
					info.setCheck27(item.getCheck27());
				}
				if (!StringUtils.isEmpty(item.getCheck28())) {
					info.setCheck28(item.getCheck28());
				}
				if (!StringUtils.isEmpty(item.getCheck29())) {
					info.setCheck29(item.getCheck29());
				}
				if (!StringUtils.isEmpty(item.getCheck30())) {
					info.setCheck30(item.getCheck30());
				}
				if (!StringUtils.isEmpty(item.getCheck31())) {
					info.setCheck31(item.getCheck31());
				}
				if (!StringUtils.isEmpty(item.getCheck32())) {
					info.setCheck32(item.getCheck32());
				}
				if (!StringUtils.isEmpty(item.getCheck33())) {
					info.setCheck33(item.getCheck33());
				}
				if (!StringUtils.isEmpty(item.getCheck34())) {
					info.setCheck34(item.getCheck34());
				}
				if (!StringUtils.isEmpty(item.getCheck35())) {
					info.setCheck35(item.getCheck35());
				}
				if (!StringUtils.isEmpty(item.getCheck36())) {
					info.setCheck36(item.getCheck36());
				}
				if (!StringUtils.isEmpty(item.getCheck37())) {
					info.setCheck37(item.getCheck37());
				}
				if (!StringUtils.isEmpty(item.getCheck38())) {
					info.setCheck38(item.getCheck38());
				}
				if (!StringUtils.isEmpty(item.getCheck39())) {
					info.setCheck39(item.getCheck39());
				}
				if (!StringUtils.isEmpty(item.getCheck40())) {
					info.setCheck40(item.getCheck40());
				}
				if (!StringUtils.isEmpty(item.getCheck41())) {
					info.setCheck41(item.getCheck41());
				}
				if (!StringUtils.isEmpty(item.getCheck42())) {
					info.setCheck42(item.getCheck42());
				}
				if (!StringUtils.isEmpty(item.getCheck43())) {
					info.setCheck43(item.getCheck43());
				}
				if (!StringUtils.isEmpty(item.getCheck44())) {
					info.setCheck44(item.getCheck44());
				}
				if (!StringUtils.isEmpty(item.getCheck45())) {
					info.setCheck45(item.getCheck45());
				}
				if (!StringUtils.isEmpty(item.getCheck46())) {
					info.setCheck46(item.getCheck46());
				}
				if (!StringUtils.isEmpty(item.getCheck47())) {
					info.setCheck47(item.getCheck47());
				}
				if (!StringUtils.isEmpty(item.getCheck48())) {
					info.setCheck48(item.getCheck48());
				}
				if (!StringUtils.isEmpty(item.getCheck49())) {
					info.setCheck49(item.getCheck49());
				}
				if (!StringUtils.isEmpty(item.getCheck50())) {
					info.setCheck50(item.getCheck50());
				}
				if (!StringUtils.isEmpty(item.getSuname())) {
					info.setSuname(item.getSuname());
				}
				if (!StringUtils.isEmpty(item.getSuname2())) {
					info.setSuname2(item.getSuname2());
				}
				response.addAntiDataList(info);
			}
		}
		return response.build();
	}
}
