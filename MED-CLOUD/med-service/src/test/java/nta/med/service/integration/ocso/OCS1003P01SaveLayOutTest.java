package nta.med.service.integration.ocso;

import java.util.ArrayList;
import java.util.List;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsoModelProto;
import nta.med.service.ihis.proto.OcsoServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OCS1003P01SaveLayOutTest extends MessageRequestTest {
	@Test
	public void testOCS1003P01SaveLayOut() throws InterruptedException {

		List<OcsoModelProto.OCS1003P01LaySaveLayoutListItemInfo> list = new ArrayList<OcsoModelProto.OCS1003P01LaySaveLayoutListItemInfo>();
		OcsoModelProto.OCS1003P01LaySaveLayoutListItemInfo.Builder item = OcsoModelProto.OCS1003P01LaySaveLayoutListItemInfo
				.newBuilder();

		item.setPkocskey("4781");
		item.setNaewonType("0");
		item.setHangmogCode("XN008");
		item.setSpecimenCode("40");
		item.setNalsu("1");
		item.setJundalTable("CPL");
		
		//item.setJusaSpdGubun("ml/hr");
		item.setJusaSpdGubun("1");
		
		
		item.setAfterActYn("N");
		item.setNurseConfirmDate("2016/03/02");
		item.setHomeCareYn("N");
		item.setGeneralDispYn("N");
		item.setApproveYn("N");
		 
		item.setBunho("00AA10037");
		item.setInputId("NV00002");
		item.setGroupSer("404");
		item.setSuryang("1");
		item.setJundalPart("CPL");
		item.setPay("0");
		
		item.setBannabYn("N"); 
		item.setOcsFlag("1");
		 
		item.setBichiYn("N");
		item.setPowderYn("N");
		
		item.setBomOccurYn("N"); 
		item.setNurseConfirmDate("1055");
		 
		item.setRegularYn("N");
		
		item.setDrgPackYn("N"); 
		item.setInsteadYn("N");
		item.setPortableYn("N");
		 
		item.setOrderDate("2016/03/04");
		item.setInputPart("01");
		item.setSlipCode("G01");
		item.setOrdDanui("000");
		item.setBogyongCode("110039");
		item.setMovePart("CT");
		item.setSgCode("C01");
		
		item.setDrgBunho("1"); 
		item.setTelYn("N");
		 
		item.setInputTab("07");
		item.setGwa("01");
		item.setInputGubun("D0");
		item.setNdayYn("N");
		item.setDvTime("*");
		item.setEmergency("N");
		
		item.setMuhyo("N"); 
		item.setSgYmd("2016/03/02");
		item.setDisplayYn("Y");
		 
		item.setDangilGumsaOrderYn("Y");
		item.setHubalChangeYn("N"); 
		item.setInOutKey("962");
		item.setDoctor("01247OCS");
		item.setSeq("1");
		item.setOrderGubun("0E");
		item.setDv("1");
		item.setJaeryoJundalYn("N");
		item.setPortableYn("N");
		item.setDcYn("N");
		item.setWonyoiOrderYn("N");
		item.setNurseConfirmUser("NV00001");
		item.setDangilGumsaResultYn("N");
		item.setImsiDrugYn("N");
		item.setWonnaeDrgYn("%");
		item.setRowState("Added");
		list.add(item.build());

		
		OcsoModelProto.OCS1003P01LaySaveLayoutListItemInfo.Builder item2 =OcsoModelProto.OCS1003P01LaySaveLayoutListItemInfo .newBuilder();
		item2.setNaewonType("0"); 
		item2.setHangmogCode("TDV003");
		item2.setSpecimenCode("*"); 
		item2.setNalsu("5");
		item2.setJundalTable("DRG"); 
		item2.setGeneralDispYn("N");
		item2.setApproveYn("N"); 
		item2.setBunho("00AA10032");
		item2.setInputId("NV00001"); 
		item2.setGroupSer("108");
		item2.setSuryang("1"); 
		item2.setJundalPart("PA"); 
		item2.setPay("0");
		item2.setBichiYn("N"); 
		item2.setPowderYn("N");
		item2.setRegularYn("N"); 
		item2.setDrgPackYn("N");
		item2.setInsteadYn("N"); 
		item2.setPortableYn("N");
		item2.setOrderDate("2016/03/02"); 
		item2.setInputPart("01");
		item2.setSlipCode("P01"); 
		item2.setOrdDanui("008");
		item2.setBogyongCode("110040"); 
		item2.setMovePart("PA");
		item2.setSgCode("611170639"); 
		item2.setInputTab("01");
		item2.setGwa("01"); 
		item2.setInputGubun("D0"); 
		item2.setNdayYn("Y");
		item2.setDvTime("/"); 
		item2.setEmergency("N");
		item2.setHubalChangeYn("N"); 
		item2.setInOutKey("962");
		item2.setDoctor("01NV00001"); 
		item2.setOrderGubun("0C");
		item2.setDv("3"); 
		item2.setPortableYn("N");
		item2.setWonyoiOrderYn("N"); 
		item2.setWonnaeDrgYn("Y");
		item2.setRowState("Added"); 
		list.add(item2.build());
		 
		OcsoServiceProto.OCS1003P01SaveLayOutRequest request = OcsoServiceProto.OCS1003P01SaveLayOutRequest.newBuilder()

				.setUserId("247OCS")
				//.setHospCodeLink("264")
				.setNaewonKey("962")
				.setNaewonDate("2016/03/04")
				.addAllLaySaveList(list)
				.build();

		sentRequestToMedApp(request, OcsoServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
