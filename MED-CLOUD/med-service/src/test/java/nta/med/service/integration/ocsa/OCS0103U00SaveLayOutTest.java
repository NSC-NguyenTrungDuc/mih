package nta.med.service.integration.ocsa;

import nta.med.core.glossary.DataRowState;
import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.integration.MessageRequestTest;
import org.junit.Test;

import java.util.ArrayList;
import java.util.List;

/**
 * @author Tiepnm
 */
public class OCS0103U00SaveLayOutTest extends MessageRequestTest {

    @Test
    public  void testOCS0103U00SaveLayOut() throws InterruptedException {
    	
/*		OCS0103U00SaveLayoutRequest[user_id: "346ADM" grd_ocs0103_item { 
		upd_date: "2013/02/18" 
		hangmog_code: "9000100" 
		hangmog_name: "\347\267\217\343\203\223\343\203\252\343\203\253\343\203\223\343\203\263 [\350\241\200\346\270\205]"
		slip_code: "B01" group_yn: "N" position: "1" seq: "100" order_gubun: "F" input_control: "4" jundal_table_out: "CPL" jundal_table_inp: "CPL" 
		jundal_part_out: "CPL" jundal_part_inp: "CPL" move_part: "CPL" dv_time: "*" ord_danui: "000" suga_yn: "Y" sg_code: "160017010" jaeryo_yn: "N" 
		hangmog_name_inx: "\347\267\217\343\203\223\343\203\252\343\203\253\343\203\223\343\203\263 [\350\241\200\346\270\205] 9000100  \357\274\242\357\274\251\357\274\254\357\274\217\347\267\217 160017010 " 
		display_yn: "Y" start_date: "2012/04/01" end_date: "9998/12/31" specimen_yn: "Y" specimen_default: "03" reser_yn_out: "N" 
		reser_yn_inp: "N" emergency: "Z" bom_yn: "N" return_yn: "N" nday_yn: "N" muhyo_yn: "N" inv_jundal_yn: "N" remark: "20121012" 
		default_suryang: "1.0" nurse_input_yn: "Y" supply_input_yn: "Y" upd_id: "ADM001" 
		slip_name: "\345\206\205\345\210\206\346\263\214\346\244\234\346\237\273A\357\274\210\347\224\237\345\214\226\357\274\211" 
		jundal_part_out_name: "\346\244\234\344\275\223\346\244\234\346\237\273\345\256\244" jundal_part_inp_name: "\346\244\234\344\275\223\346\244\234\346\237\273\345\256\244" 
		move_part_name: "\346\244\234\344\275\223\346\244\234\346\237\273\345\256\244" if_input_control: "P" sg_name: "\357\274\242\357\274\251\357\274\254\357\274\217\347\267\217" 
		sg_danui_name: "\347\204\241" result_gubun: "S" trial: "N" row_state: "Modified" 
		hosp_code: "346"]*/
    	
    	
        OcsaModelProto.OCS0103U00GrdOCS0103Info.Builder info = OcsaModelProto.OCS0103U00GrdOCS0103Info.newBuilder();
        info.setRowState(DataRowState.ADDED.getValue());
        info.setHospCode("346");
        info.setStartDate("2012/02/18");
        info.setUpdDate("2013/02/18"); 
        info.setHangmogCode("9000100"); 
        info.setHangmogName("Ph\341\272\253u thu\341\272\255t c\341\272\245y 1 Implant c\303\263 gh\303\251p x\306\260\306\241ng m\341\273\231t m\341\272\267t (bao g\341\273\223m c\341\272\243 l\303\240m r\304\203ng gi\341\272\243 tr\303\252n implant)");
        info.setSlipCode("B01");
        info.setGroupYn("N");
        info.setPosition("1");
        info.setSeq("100");
        info.setOrderGubun("F");
        info.setInputControl("4");
        info.setJundalTableOut("CPL");
        info.setJundalTableInp("CPL");
        info.setJundalPartOut("CPL");
        info.setJundalPartInp("CPL");
        info.setMovePart("CPL");
        info.setDvTime("*");
        info.setOrdDanui("000");
        info.setSugaYn("Y");
        info.setSgCode("160017010");
        info.setJaeryoYn("N");
        info.setHangmogNameInx("\347\267\217\343\203\223\343\203\252\343\203\253\343\203\223\343\203\263 [\350\241\200\346\270\205] 9000100  \357\274\242\357\274\251\357\274\254\357\274\217\347\267\217 160017010 ");
        info.setDisplayYn("Y");
		info.setEndDate("9998/12/31");
    			
    			
        List<OcsaModelProto.OCS0103U00GrdOCS0103Info> ocs0103U00GrdOCS0103Infos = new ArrayList<>();
        ocs0103U00GrdOCS0103Infos.add(info.build());

        OcsaServiceProto.OCS0103U00SaveLayoutRequest request = OcsaServiceProto.OCS0103U00SaveLayoutRequest.newBuilder().addAllGrdOcs0103Item(ocs0103U00GrdOCS0103Infos).setHospCode("K02").build();

        sentRequestToMedApp(request, OcsaServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
    }
}
