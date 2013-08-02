import sys
import os
import shutil

def main(argv):
  bd = argv[1]
  sf = argv[2]
  assert(sf[-5:] == '.java')
  icf = sf[:-5]+'.class'
  ocf = os.path.join(bd, sf[:-5]+'.class')
  if os.path.exists(icf): os.unlink(icf)
  os.system('javac '+sf)
  shutil.copyfile(icf, ocf)

if __name__ == '__main__':
  main(sys.argv)